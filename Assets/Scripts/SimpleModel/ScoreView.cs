using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _image;

    private int _score;

    public Vector3 Position => _text.transform.position;

    public void Show()
    {
        _text.enabled = true;
        _image.enabled = false;

        _score = 0;
        _text.text = _score.ToString();
    }

    public void IncreaseScore(int value)
    {
        _score += value;
        _text.text = _score.ToString();
    }

    public void Hide()
    {
        _text.enabled = false;
        _image.enabled = true;
    }

    private void Awake()
    {
        Hide();
    }
}
