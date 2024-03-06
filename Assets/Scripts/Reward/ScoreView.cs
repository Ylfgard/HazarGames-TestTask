using TMPro;
using UnityEngine;

namespace Reward
{
    internal class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void ShowScore() => _text.enabled = true;
        public void HideScore() => _text.enabled = false;
        public void UpdateScore(int score) => _text.text = score.ToString();
    }
}