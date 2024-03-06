using System;

namespace GameStateController
{
    public interface IStateNotifier
    {
        event Action OnActive;
        event Action OnReward;
        event Action OnCooldown;
    }
}