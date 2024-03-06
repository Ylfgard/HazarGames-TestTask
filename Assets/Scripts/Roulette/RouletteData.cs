using GameStateController;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Roulette
{
    internal class RouletteData : MonoBehaviour, IRouletteData
    {
        public event System.Action<int> RolledValue;

        [SerializeField] private RouletteSlotsKeeper _slotsKeeper;
        [SerializeField] private RouletteView _view;

        [SerializeField] private int _spinCount = 3;
        [SerializeField] private float _spinDuration = 1.5f;

        private IStateNotifier _stateNotifier;

        [Inject]
        private void Construct(IStateNotifier stateNotifier)
        {
            _stateNotifier = stateNotifier;
            _stateNotifier.OnReward += SpinWheel;
        }

        private void SpinWheel()
        {
            int slotsCount = _slotsKeeper.Slots.Length;
            int newSlot = Random.Range(0, slotsCount);

            int sectionAngle = 360 / slotsCount;
            int rotateAngle = sectionAngle * newSlot;
            rotateAngle = 360 * _spinCount + rotateAngle + sectionAngle / 2;
            _view.SpinWheel(rotateAngle, _spinDuration);

            StartCoroutine(DelayBeforeReward(_slotsKeeper.Slots[newSlot].Value));
        }

        private IEnumerator DelayBeforeReward(int value)
        {
            Debug.Log(value);
            yield return new WaitForSeconds(_spinDuration);
            RolledValue?.Invoke(value);
        }

        private void OnDestroy()
        {
            _stateNotifier.OnReward -= SpinWheel;
        }
    }
}
