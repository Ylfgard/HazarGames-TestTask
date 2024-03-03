using UnityEngine;

public class RewardGiver : MonoBehaviour
{
    private const int MaxRewardsCount = 20;

    private Reward[] _rewards;

    private void Awake()
    {
        _rewards = new Reward[MaxRewardsCount];
        for (int i = 0; i < MaxRewardsCount; i++)
            _rewards[i] = new Reward();
    }

    public void GiveReward(int value)
    {
        int reward = Mathf.FloorToInt(value / MaxRewardsCount);
        int biggerCount = value % MaxRewardsCount;
        for (int i = 0; i < biggerCount; i++)
        {
            _rewards[i].SetReward(reward + 1);
            Debug.Log(_rewards[i].Value);
        }

        if (reward == 0) return;
        for (int i = biggerCount; i < MaxRewardsCount; i++)
        {
            _rewards[i].SetReward(reward);
            Debug.Log(_rewards[i].Value);
        }
    }
}