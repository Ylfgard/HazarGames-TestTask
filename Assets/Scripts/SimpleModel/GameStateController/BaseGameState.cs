using System;

namespace GameStateController
{
    public abstract class BaseGameState
    {
        public event Action EnteredState;
        protected GameStateController _controller;

        public BaseGameState(GameStateController controller)
        {
            _controller = controller;
        }

        public virtual void EnterState()
        {
            EnteredState?.Invoke();
        }
    }
}