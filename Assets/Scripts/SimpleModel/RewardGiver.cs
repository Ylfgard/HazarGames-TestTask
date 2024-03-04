using UnityEngine;

public class RewardGiver : MonoBehaviour
{
    [SerializeField] private RewardGenerator _generator;
    [SerializeField] private RewardSpawner _spawner;

    public void GiveReward(int value)
    {
        _spawner.StartSpawn();

        int reward = Mathf.FloorToInt(value / ConstantKeeper.MAX_REWARDS_COUNT);
        var sprite = _generator.CurReward;
        int biggerCount = value % ConstantKeeper.MAX_REWARDS_COUNT;
        for (int i = 0; i < biggerCount; i++)
            _spawner.Spawn(reward + 1, sprite);

        if (reward == 0) return;
        for (int i = biggerCount; i < ConstantKeeper.MAX_REWARDS_COUNT; i++)
            _spawner.Spawn(reward, sprite);
    }
}