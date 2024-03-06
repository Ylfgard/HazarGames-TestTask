using GameStateController;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Roulette
{
    internal class RouletteSlotsGenerator : MonoBehaviour
    {
        [SerializeField] private RouletteSlotsKeeper _keeper;

        [SerializeField] private int _valuesCount = 20;

        private ICooldownTimer _cooldownTimer;
        private int[] _values;

        private void Awake()
        {
            _values = new int[_valuesCount];

            for (int i = 1; i <= _valuesCount; i++)
                _values[i - 1] = i * 5;
        }

        [Inject]
        private void Construct(ICooldownTimer cooldownTimer)
        {
            _cooldownTimer = cooldownTimer;
            _cooldownTimer.Ticked += GenerateSlots;
        }

        public void GenerateSlots(int t)
        {
            if (_keeper.Slots.Length > _valuesCount)
            {
                Debug.LogError("Wrongs slots count!");
                return;
            }

            List<int> values = _values.ToList();
            for (int i = 0; i < _keeper.Slots.Length; i++)
            {
                int index = Random.Range(0, values.Count);
                _keeper.Slots[i].SetValue(values[index]);
                values.Remove(values[index]);
            }
        }

        private void OnDestroy()
        {
            _cooldownTimer.Ticked -= GenerateSlots;
        }
    }
}