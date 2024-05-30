using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{_reference}\n");
        foreach (var word in _words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }

    public void HideWords()
    {
        Random random = new Random();
        int visibleWordsCount = _words.Count(word => word.IsVisible);
        int wordsToHide = Math.Min(random.Next(1, 4), visibleWordsCount);

        while (wordsToHide > 0)
        {
            Word word = _words[random.Next(_words.Count)];
            if (word.IsVisible)
            {
                word.ToggleVisibility();
                wordsToHide--;
            }
        }
    }

    public bool AreAllWordsHidden()
    {
        return _words.All(word => !word.IsVisible);
    }
}

public class Reference
{
    private string _book;
    private int _startChapter;
    private int _startVerse;
    private int? _endChapter;
    private int? _endVerse;

    public Reference(string book, int startChapter, int startVerse)
    {
        _book = book;
        _startChapter = startChapter;
        _startVerse = startVerse;
    }

    public Reference(string book, int startChapter, int startVerse, int endChapter, int endVerse)
    {
        _book = book;
        _startChapter = startChapter;
        _startVerse = startVerse;
        _endChapter = endChapter;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        if (_endChapter.HasValue && _endVerse.HasValue)
        {
            return $"{_book} {_startChapter}:{_startVerse}-{_endChapter}:{_endVerse}";
        }
        else
        {
            return $"{_book} {_startChapter}:{_startVerse}";
        }
    }
}

public class Word
{
    private string _text;
    private bool _isVisible;

    public Word(string text)
    {
        _text = text;
        _isVisible = true;
    }

    public bool IsVisible => _isVisible;

    public void ToggleVisibility()
    {
        _isVisible = !_isVisible;
    }

    public override string ToString()
    {
        return _isVisible ? _text : "_____";
    }
}

class Program
{
    static void Main()
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (true)
        {
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideWords();

            if (scripture.AreAllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine("All words are hidden!");
                break;
            }
        }
    }
}
