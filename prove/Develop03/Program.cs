using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        //Reference reference = new Reference("John", 3, 16, 18);
        //Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        Reference reference = new Reference("Jacob", 3, 6);
        Scripture scripture = new Scripture(reference, "And now, this commandment they observe to keep; wherefore, because of this observance, in keeping this commandment, the Lord God will not destroy them, but will be merciful unto them; and one day they shall become a blessed people.");

        while (true)
        {
            scripture.Display();
            Console.WriteLine("\nEnter the number of words to hide or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            if (int.TryParse(input, out int numberOfWordsToHide))
            {
                scripture.HideWords(numberOfWordsToHide);

                if (scripture.AreAllWordsHidden())
                {
                    Console.Clear();
                    Console.WriteLine("All words are hidden!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number or 'quit' to exit.");
            }
        }

    }
}
