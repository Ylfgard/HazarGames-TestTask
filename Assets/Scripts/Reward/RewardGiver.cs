using GameStateController;
using Roulette;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Reward
{
    internal class RewardGiver : MonoBehaviour, IRewardGiver
    {
        public event Action<int> RewardGived;

        [SerializeField] private RewardTypeSelector _generator;
        [SerializeField] private RewardView _prefab;

        [Header ("Reward Parameters")]
        [SerializeField] private Transform _spawnCenter;
        [SerializeField] private Transform _rouletteCenter;
        [SerializeField] private SpawnData _spawnData;
        [SerializeField] private int _maxRewardsCount = 20;
        [SerializeField] private float _rewardEndDelay = 2f;

        private RewardSpawner _spawner;
        private StateNotifier _stateNotifier;
        private IRouletteData _rouletteData;

        private void Awake()
        {
            _spawner = new RewardSpawner(_prefab, _spawnData, _maxRewardsCount, 
                _spawnCenter, _rouletteCenter.position);
        }

        [Inject]
        private void Construct(StateNotifier stateNotifier, IRouletteData rouletteData)
        {
            _stateNotifier = stateNotifier;

            _rouletteData = rouletteData;
            _rouletteData.RolledValue += GiveReward;
        }

        private void GiveReward(int value)
        {
            float maxDuration = 0;
            int reward = Mathf.FloorToInt(value / _maxRewardsCount);
            int biggerCount = value % _maxRewardsCount;
            for (int i = 0; i < biggerCount; i++)
                maxDuration = SpawnReward(maxDuration, reward + 1);

            if (reward == 0)
            {
                StartCoroutine(RewardEndDelay(maxDuration + _rewardEndDelay));
                return;
            }
            for (int i = biggerCount; i < _maxRewardsCount; i++)
                maxDuration = SpawnReward(maxDuration, reward);

            StartCoroutine(RewardEndDelay(maxDuration + _rewardEndDelay));
        }

        private float SpawnReward(float maxDuration, int reward)
        {
            var duration = _spawner.Spawn(_generator.CurReward);
            StartCoroutine(RewardGiveDelay(duration, reward));
            return duration > maxDuration ? duration : maxDuration;
        }

        private IEnumerator RewardGiveDelay(float delay, int reward)
        {
            yield return new WaitForSeconds(delay - 0.1f);
            RewardGived?.Invoke(reward);
        }

        private IEnumerator RewardEndDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            _stateNotifier.SwitchToCooldown();
        }

        private void OnDestroy()
        {
            _rouletteData.RolledValue -= GiveReward;
        }
    }
}