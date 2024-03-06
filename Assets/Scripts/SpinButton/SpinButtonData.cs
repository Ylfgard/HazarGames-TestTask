using GameStateController;
using UnityEngine;
using Zenject;

namespace SpinButton
{
    internal class SpinButtonData : MonoBehaviour
    {
        [SerializeField] private SpinButtonController _controller;
        [SerializeField] private SpinButtonView _view;
        
        private IStateNotifier _stateNotifier;
        private ICooldownTimer _cooldownTimer;

        [Inject]
        private void Construct(IStateNotifier stateNotifier, ICooldownTimer cooldownTimer)
        {
            _stateNotifier = stateNotifier;
            _stateNotifier.OnActive += UnlockButton;
            _stateNotifier.OnReward += LockButton;
            _stateNotifier.OnCooldown += OnCooldown;

            _cooldownTimer = cooldownTimer;
            _cooldownTimer.Ticked += _view.UpdateTimer;
        }

        private void LockButton()
        {
            _controller.ChangeInputActivity(false);
        }

        private void UnlockButton()
        {
            _controller.ChangeInputActivity(true);
            _view.UnlockButton(ConstantsKeeper.TRY_LUCK);
        }

        private void OnCooldown()
        {
            LockButton();
            _view.ShowTimer();
        }

        private void OnDestroy()
        {
            _stateNotifier.OnActive -= UnlockButton;
            _stateNotifier.OnReward -= LockButton;
            _stateNotifier.OnCooldown -= OnCooldown;
            _cooldownTimer.Ticked -= _view.UpdateTimer;
        }
    }
}