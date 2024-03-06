using TMPro;
using UnityEngine;

namespace SpinButton
{
    internal class SpinButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Color _textColor;
        [SerializeField] private Color _timerColor;

        public void UnlockButton(string text)
        {
            _text.text = text;
            _text.color = _textColor;
        }

        public void ShowTimer()
        {
            _text.color = _timerColor;
        }

        public void UpdateTimer(int time)
        {
            _text.text = time.ToString();
        }
    }
}
