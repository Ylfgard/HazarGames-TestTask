using UnityEngine;
using UnityEngine.UI;

namespace Reward
{
    internal class RewardTypeView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        public void ShowRewardType() => _image.enabled = true;
        public void HideRewardType(int i) => _image.enabled = false;
        public void DisplayRewardType(Sprite sprite) => _image.sprite = sprite;
    }
}
