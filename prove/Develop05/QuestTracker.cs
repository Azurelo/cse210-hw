
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
        int goalNumber = int.Parse(Console.ReadLine()) - 1;

        if (goalNumber < 0 || goalNumber >= _quests.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        _quests[goalNumber].RecordEvent(ref _totalPoints);
        CheckLevelUp();
    }

    public void DisplayGoals()
    {
        Console.WriteLine("===== Display Goals =====");
        for (int i = 0; i < _quests.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_quests[i].ToString()}");
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
                writer.WriteLine(quest.ToString());
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

                Quest quest = null;

                switch (type)
                {
                    case "SimpleQuest":
                        bool isComplete = bool.Parse(parts[4]);
                        quest = new SimpleQuest(name, description, points, isComplete);
                        break;
                    case "EternalQuest":
                        quest = new EternalQuest(name, description, points);
                        break;
                    case "ListQuest":
                        int targetCount = int.Parse(parts[4]);
                        int currentCount = int.Parse(parts[5]);
                        int bonusPoints = int.Parse(parts[6]);
                        quest = new ListQuest(name, description, points, targetCount, currentCount, bonusPoints);
                        break;
                }

                _quests.Add(quest);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    public void CheckLevelUp()
    {
        int newLevel = _totalPoints / 1000;
        if (newLevel > _level)
        {
            int levelUps = newLevel - _level;
            _level = newLevel;
            _goldCoins += levelUps;
            Console.WriteLine($"Congratulations! You leveled up to Level {_level} and earned {levelUps} gold coin(s).");
        }
    }

    public void RedeemGoldCoins()
    {
        Console.WriteLine("===== Redeem Gold Coins =====");
        Console.WriteLine("You can redeem your gold coins for treats.");
        Console.WriteLine("1 gold coin = 1 treat.");

        Console.Write("Enter the number of gold coins to redeem: ");
        int coinsToRedeem = int.Parse(Console.ReadLine());

        if (coinsToRedeem <= 0 || coinsToRedeem > _goldCoins)
        {
            Console.WriteLine("Invalid number of coins.");
            return;
        }

        _goldCoins -= coinsToRedeem;
        Console.WriteLine($"You redeemed {coinsToRedeem} gold coin(s) for {coinsToRedeem} treat(s). Enjoy!");
    }
}