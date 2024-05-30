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

    public Reference(string book, int startChapter, int startVerse, int endVerse)
    {
        _book = book;
        _startChapter = startChapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        if (_endVerse.HasValue)
        {
            return $"{_book} {_startChapter}:{_startVerse}-{_endChapter}:{_endVerse}";
        }
        else
        {
            return $"{_book} {_startChapter}:{_startVerse}";
        }
    }
}