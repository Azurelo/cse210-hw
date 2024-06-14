using System;
using System.Collections.Generic;
using System.Threading;

using System;
using System.Collections.Generic;
using System.Threading;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Stretching Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            if (choice == "4") break;

            Console.Write("Enter the duration of the activity in seconds: ");
            int duration = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    var breathingActivity = new Breathing(duration);
                    breathingActivity.PerformActivity();
                    break;
                case "2":
                    var reflectionActivity = new Reflection(duration);
                    reflectionActivity.PerformActivity();
                    break;
                case "3":
                    var listingActivity = new Listing(duration);
                    listingActivity.PerformActivity();
                    break;
                case "4":
                var stretchingActivity = new Stretching(duration);
                stretchingActivity.PerformActivity();
                break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}