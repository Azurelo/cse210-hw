using System;
using System.Collections.Generic;
using System.IO;

namespace QuestTrackerApp
{
    class QuestTracker
    {
        private List<Quest> _quests;
        private int _totalPoints;
        private int _level;
        private int _goldCoins;

        public QuestTracker()
        {
            _quests = new List<Quest>();
            _totalPoints = 0;
            _level = 1;
            _goldCoins = 0;
        }

        public void CreateGoal()
        {
            Console.WriteLine("===== Create a New Goal =====");
            Console.WriteLine("Select goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();

            Console.Write("Enter points: ");
            int points = int.Parse(Console.ReadLine());

            Quest quest = null;

            switch (choice)
            {
                case "1":
                    quest = new SimpleQuest(name, description, points);
                    break;
                case "2":
                    quest = new EternalQuest(name, description, points);
                    break;
                case "3":
                    Console.Write("Enter target count: ");
                    int targetCount = int.Parse(Console.ReadLine());

                    Console.Write("Enter bonus points: ");
                    int bonusPoints = int.Parse(Console.ReadLine());

                    quest = new ListQuest(name, description, points, targetCount, bonusPoints);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            _quests.Add(quest);
            Console.WriteLine("Goal created successfully.");
        }

        public void RecordEvent()
        {
            Console.WriteLine("===== Record an Event =====");
            DisplayGoals();

            Console.Write("Enter the number of the goal to record: ");
            if (!int.TryParse(Console.ReadLine(), out int goalNumber) || goalNumber < 1 || goalNumber > _quests.Count)
            {
                Console.WriteLine("Invalid goal number.");
                return;
            }

            _quests[goalNumber - 1].RecordEvent(ref _totalPoints);
            CheckLevelUp();
        }

        public void DisplayGoals()
        {
            Console.WriteLine("===== Display Goals =====");
            for (int i = 0; i < _quests.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_quests[i]}");
            }
            Console.WriteLine($"Total Points: {_totalPoints}");
            Console.WriteLine($"Level: {_level}");
            Console.WriteLine($"Gold Coins: {_goldCoins}");
        }

        public void SaveGoals()
        {
            Console.Write("Enter the file name to save goals: ");
            string fileName = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(_totalPoints);
                writer.WriteLine(_level);
                writer.WriteLine(_goldCoins);

                foreach (Quest quest in _quests)
                {
                    writer.WriteLine(quest);
                }
            }

            Console.WriteLine("Goals saved successfully.");
        }

        public void LoadGoals()
        {
            Console.Write("Enter the file name to load goals: ");
            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _quests.Clear();

            using (StreamReader reader = new StreamReader(fileName))
            {
                _totalPoints = int.Parse(reader.ReadLine());
                _level = int.Parse(reader.ReadLine());
                _goldCoins = int.Parse(reader.ReadLine());

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string type = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    Quest quest = type switch
                    {
                        "SimpleQuest" => new SimpleQuest(name, description, points, bool.Parse(parts[4])),
                        "EternalQuest" => new EternalQuest(name, description, points),
                        "ListQuest" => new ListQuest(name, description, points, int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])),
                        _ => null
                    };

                    if (quest != null)
                    {
                        _quests.Add(quest);
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }

        public void CheckLevelUp()
        {
            int requiredPoints = _level * 100;
            if (_totalPoints >= requiredPoints)
            {
                _level++;
                _goldCoins += 10;
                Console.WriteLine($"Congratulations! You leveled up to Level {_level}. You earned 10 gold coins.");
            }
        }

        public void RedeemGoldCoins()
    {
        Console.WriteLine("\nTreats Menu:");
        Console.WriteLine("1. Chocolate Bar - 1 gold coin");
        Console.WriteLine("2. Ice Cream - 2 gold coins");
        Console.WriteLine("3. Movie Ticket - 5 gold coins");
        Console.Write("Choose a treat to redeem: ");

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            return;
        }

        int cost = 0;
        string treat = "";

        switch (choice)
        {
            case 1:
                cost = 1;
                treat = "Chocolate Bar";
                break;
            case 2:
                cost = 2;
                treat = "Ice Cream";
                break;
            case 3:
                cost = 5;
                treat = "Movie Ticket";
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                return;
        }

        if (_goldCoins >= cost)
        {
            _goldCoins -= cost;
            Console.WriteLine($"You redeemed {cost} gold coin(s) for a {treat}. Enjoy your treat!");
        }
        else
        {
            Console.WriteLine("You do not have enough gold coins.");
        }
    }}
}
