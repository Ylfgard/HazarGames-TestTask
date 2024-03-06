using GameStateController;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SpinButton
{
    internal class SpinButtonController : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private StateNotifier _stateNotifier;

        private void Awake()
        {
            _button.onClick.AddListener(SpinWheel);
        }

        [Inject]
        private void Construct(StateNotifier stateNotifier)
        {
            _stateNotifier = stateNotifier;
        }

        public void ChangeInputActivity(bool isActive)
        {
            _button.interactable = isActive;
        }

        private void SpinWheel()
        {
            _stateNotifier.SwitchToReward();
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(SpinWheel);
        }
    }
}
