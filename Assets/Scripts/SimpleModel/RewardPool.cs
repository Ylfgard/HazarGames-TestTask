using UnityEngine.Pool;
using UnityEngine;

public class RewardPool
{
    private RewardView _prefab;
    private Transform _parent;
    private Vector3 _scorePosition;
    private ObjectPool<RewardView> _pool;

    public RewardPool(RewardView prefab, Transform parent, Vector3 scorePosition)
    {
        _prefab = prefab;
        _parent = parent;
        _scorePosition = scorePosition;
        _pool = new ObjectPool<RewardView>(
                OnCreateReward,
                (RewardView reward) => reward.gameObject.SetActive(true),
                (RewardView reward) => reward.gameObject.SetActive(false),
                (RewardView reward) => GameObject.Destroy(reward), 
                false, ConstantKeeper.MAX_REWARDS_COUNT
            );
    }

    public RewardView Get() => _pool.Get();
    public void Release(RewardView reward) => _pool.Release(reward);

    private RewardView OnCreateReward()
    {
        RewardView reward = GameObject.Instantiate(_prefab, _parent);
        reward.Init(_scorePosition);
        return reward;
    }
}
