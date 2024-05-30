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