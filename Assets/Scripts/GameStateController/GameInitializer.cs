using UnityEngine;
using Zenject;

namespace GameStateController
{
    internal class GameInitializer : MonoBehaviour
    {
        private StateNotifier _stateNotifier;

        [Inject]
        private void Construct(StateNotifier stateNotifier)
        {
            _stateNotifier = stateNotifier;
        }

        private void Start()
        {
            _stateNotifier.SwitchToCooldown();
        }
    }
}