using System;
using System.Threading.Tasks;
using Zenject;

namespace GameStateController
{
    internal class CooldownTimer : ICooldownTimer
    {
        public event Action<int> Ticked;

        private StateNotifier _stateNotifier;
        private int _curTime;

        [Inject]
        private void Construct(StateNotifier stateNotifier)
        {
            _stateNotifier = stateNotifier;
            _stateNotifier.OnCooldown += StartTicking;
        }

        private async void StartTicking()
        {
            for (_curTime = ConstantsKeeper.COOLDOWN_DURATION; _curTime > 0; _curTime--)
            {
                Ticked?.Invoke(_curTime);
                await Task.Delay(1000);
            }

            Ticked?.Invoke(_curTime);
            _stateNotifier.SwitchToActive();
        }

        ~CooldownTimer()
        {
            _stateNotifier.OnCooldown -= StartTicking;
        }
    }
}
