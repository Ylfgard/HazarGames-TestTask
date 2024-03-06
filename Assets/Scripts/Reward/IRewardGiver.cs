using System;

namespace Reward
{
    internal interface IRewardGiver
    {
        event Action<int> RewardGived;
    }
}