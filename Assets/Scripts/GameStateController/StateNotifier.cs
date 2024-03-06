using System;

namespace GameStateController
{
    internal class StateNotifier : IStateNotifier
    {
        public event Action OnActive;
        public event Action OnReward;
        public event Action OnCooldown;

        public void SwitchToActive()
        {
            OnActive?.Invoke();
        }

        public void SwitchToReward()
        {
            OnReward?.Invoke();
        }

        public void SwitchToCooldown()
        {
            OnCooldown?.Invoke();
        }
    }
}