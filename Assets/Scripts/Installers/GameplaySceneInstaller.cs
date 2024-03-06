using GameStateController;
using Zenject;
using UnityEngine;
using Roulette;
using Reward;

namespace Installers
{
    internal class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private RouletteData _rouletteData;
        [SerializeField] private RewardGiver _rewardGiver;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StateNotifier>().AsSingle();
            Container.BindInterfacesTo<CooldownTimer>().AsSingle();
            Container.Bind<IRouletteData>().FromInstance(_rouletteData).AsSingle();
            Container.Bind<IRewardGiver>().FromInstance(_rewardGiver).AsSingle();
        }
    }
}