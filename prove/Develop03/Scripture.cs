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