using GameStateController;
using Roulette;
using UnityEngine;
using Zenject;

namespace Reward
{
    internal class ScoreData : MonoBehaviour
    {
        [SerializeField] private ScoreView _view;

        private int _score;
        private IStateNotifier _stateNotifier;
        private IRouletteData _rouletteData;
        private IRewardGiver _rewardGiver;

        [Inject]
        private void Construct(IStateNotifier stateNotifier, IRouletteData rouletteData, IRewardGiver rewardGiver)
        {
            _stateNotifier = stateNotifier;
            _stateNotifier.OnCooldown += _view.HideScore;

            _rouletteData = rouletteData;
            _rouletteData.RolledValue += ShowScore;

            _rewardGiver = rewardGiver;
            _rewardGiver.RewardGived += IncreaseScore;
        }

        private void ShowScore(int i)
        {
            _score = 0;
            _view.ShowScore();
            _view.UpdateScore(_score);
        }

        private void IncreaseScore(int value)
        {
            _score += value;
            _view.UpdateScore(_score);
        }

        private void OnDestroy()
        {
            _stateNotifier.OnCooldown -= _view.HideScore;
            _rouletteData.RolledValue -= ShowScore;
            _rewardGiver.RewardGived -= IncreaseScore;
        }
    }
}
