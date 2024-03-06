using System;

namespace GameStateController
{
    public interface ICooldownTimer
    {
        event Action<int> Ticked;
    }
}