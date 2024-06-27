using System;

class Program
{
    static void Main(string[] args)
    {
        QuestTracker questTracker = new QuestTracker();
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("===== Main Menu =====");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Check Level Up");
            Console.WriteLine("7. Redeem Gold Coins");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    questTracker.CreateGoal();
                    break;
                case "2":
                    questTracker.RecordEvent();
                    break;
                case "3":
                    questTracker.DisplayGoals();
                    break;
                case "4":
                    questTracker.SaveGoals();
                    break;
                case "5":
                    questTracker.LoadGoals();
                    break;
                case "6":
                    questTracker.CheckLevelUp();
                    break;
                case "7":
                    questTracker.RedeemGoldCoins();
                    break;
                case "8":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 8.");
                    break;
            }

            Console.WriteLine();
        }
    }
}