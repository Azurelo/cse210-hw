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

    public void HideWords(int numberOfWordsToHide)
    {
        Random random = new Random();
        int visibleWordsCount = _words.Count(word => word.IsVisible);
        numberOfWordsToHide = Math.Min(numberOfWordsToHide, visibleWordsCount);

        int wordsHidden = 0;
        while (wordsHidden < numberOfWordsToHide)
        {
            Word word = _words[random.Next(_words.Count)];
            if (word.IsVisible)
            {
                word.ToggleVisibility();
                wordsHidden++;
            }
        }
    }

    public bool AreAllWordsHidden()
    {
        return _words.All(word => !word.IsVisible);
    }
}