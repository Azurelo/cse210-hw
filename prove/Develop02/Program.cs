using System;
using System.Collections.Generic;
using System.IO;

//My program goes above expectations by allowing the user a new menu option to enter their own prompts for future entries.
class JournalProgram
{
    static void Main(string[] args)
    {
        Journal MyJournal = new Journal();
        bool IsRunning = true;

        while (IsRunning)
        {
            Console.WriteLine("\n1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Add a custom prompt");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nWriting a new entry...");
                    MyJournal.AddEntry();
                    break;
                case "2":
                    Console.WriteLine("\nDisplaying the journal:");
                    MyJournal.DisplayJournal();
                    break;
                case "3":
                    Console.WriteLine("\nSaving the journal to a file...");
                    MyJournal.SaveJournal();
                    break;
                case "4":
                    Console.WriteLine("\nLoading the journal from a file...");
                    MyJournal.LoadJournal();
                    break;
                case "5":
                    Console.WriteLine("\nAdding a custom prompt...");
                    MyJournal.AddCustomPrompt();
                    break;
                case "6":
                    IsRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}

class Journal
{
    private List<JournalEntry> _entries = new List<JournalEntry>();
    private List<string> _customPrompts = new List<string>();
    private string[] _defaultPrompts = {
        "Where did you go to today?",
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "On a scale of 1-10 how much energy did you use?"
    };

    public void AddEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");

        Console.Write("Enter your response: ");
        string response = Console.ReadLine();

        JournalEntry newEntry = new JournalEntry(prompt, response, DateTime.Now.ToString("M/d/yyyy H:mm"));
        _entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_entries[i]._date}: {_entries[i]._prompt} - {_entries[i]._response}");
        }
    }

    public void SaveJournal()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry._date}: {entry._prompt} - {entry._response}");
            }
        }
        Console.WriteLine($"Journal saved to {filename}.");
    }

    public void LoadJournal()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        _entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(new char[] { ':' }, 2);
                if (parts.Length != 2)
                {
                    continue;
                }

                string[] entryParts = parts[1].Split(new string[] { " - " }, StringSplitOptions.None);
                if (entryParts.Length != 2)
                {
                    continue;
                }

                string date = parts[0].Trim(); 
                string prompt = entryParts[0].Trim();
                string response = entryParts[1].Trim();

                JournalEntry loadedEntry = new JournalEntry(prompt, response, date);
                _entries.Add(loadedEntry);
            }
        }

        Console.WriteLine($"Journal loaded from {filename}.");
    }

    public void AddCustomPrompt()
    {
        Console.Write("Enter your custom prompt: ");
        string customPrompt = Console.ReadLine();
        _customPrompts.Add(customPrompt);
        Console.WriteLine("Custom prompt added successfully.");
    }

    private string GetRandomPrompt()
    {
        List<string> allPrompts = new List<string>(_defaultPrompts);
        allPrompts.AddRange(_customPrompts);
        Random rand = new Random();
        int index = rand.Next(allPrompts.Count);
        return allPrompts[index];
    }
}

class JournalEntry
{
    public string _prompt { get; }
    public string _response { get; }
    public string _date { get; }

    public JournalEntry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }
}