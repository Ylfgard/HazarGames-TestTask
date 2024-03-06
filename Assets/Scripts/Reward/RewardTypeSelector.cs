using GameStateController;
using Roulette;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Reward
{
    internal class RewardTypeSelector : MonoBehaviour
    {
        [SerializeField] private RewardTypeView _view;
        [SerializeField] private Sprite[] _rewards;

        private List<int> _indexes = new List<int>();
        private int _curIndex;
        private ICooldownTimer _cooldownTimer;
        private IStateNotifier _stateNotifier;
        private IRouletteData _rouletteData;

        public Sprite CurReward => _rewards[_curIndex];

        private void Awake()
        {
            for (int i = 0; i < _rewards.Length; i++)
                _indexes.Add(i);
        }

        [Inject]
        private void Construct(ICooldownTimer cooldownTimer,
            IStateNotifier stateNotifier, IRouletteData rouletteData)
        {
            _cooldownTimer = cooldownTimer;
            _cooldownTimer.Ticked += GenerateRewardType;

            _stateNotifier = stateNotifier;
            _stateNotifier.OnCooldown += _view.ShowRewardType;

            _rouletteData = rouletteData;
            _rouletteData.RolledValue += _view.HideRewardType;
        }

        private void GenerateRewardType(int time)
        {
            int i = _curIndex;
            _curIndex = _indexes[Random.Range(0, _indexes.Count)];
            _indexes.Remove(_curIndex);
            _indexes.Add(i);

            _view.DisplayRewardType(CurReward);
        }

        private void OnDestroy()
        {
            _cooldownTimer.Ticked -= GenerateRewardType;
            _stateNotifier.OnCooldown -= _view.ShowRewardType;
            _rouletteData.RolledValue -= _view.HideRewardType;
        }
    }
}