using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinButton : MonoBehaviour
{
    private const string TRY_LUCK = "Испытать удачу";

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Color _textColor;
    [SerializeField] private Color _timerColor;
    [SerializeField] private Roulette _roulette;

    public void LockButton()
    {
        _button.interactable = false;
    }

    public void UnlockButton()
    {
        _text.text = TRY_LUCK;
        _text.color = _textColor;
        _button.interactable = true;
    }

    public void ShowTimer()
    {
        LockButton();
        _text.color = _timerColor;
    }

    public void UpdateTimer(int time)
    {
        _text.text = time.ToString();
    }

    private void Awake()
    {
        _button.onClick.AddListener(SpinWheel);
    }

    private void SpinWheel()
    {
        _roulette.SpinWheel();
        LockButton();
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(SpinWheel);
    }
}
