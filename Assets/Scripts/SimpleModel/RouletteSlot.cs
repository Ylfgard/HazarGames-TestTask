using TMPro;

public class RouletteSlot
{
    public int Value { get; private set; }

    private TextMeshProUGUI _text;

    public RouletteSlot(TextMeshProUGUI text)
    {
        _text = text;
    }

    public void SetValue(int value)
    {
        Value = value;
        _text.text = value.ToString();
    }
}