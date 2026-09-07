public class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public string GetDisplayText()
    {
        if (_hidden)
        {
            string hiddenText = "";

            foreach (char character in _text)
            {
                if (char.IsLetter(character))
                {
                    hiddenText += "_";
                }
                else
                {
                    hiddenText += character;
                }
            }

            return hiddenText;
        }

        return _text;
    }
}