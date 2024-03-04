using DG.Tweening;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    private const int SPIN_COUNT = 3;
    private const float SPIN_DURATION = 1;

    [SerializeField] private RouletteSlotsKeeper _slotsKeeper;
    [SerializeField] private RewardGiver _rewardGiver;
    [SerializeField] private Transform _wheel;

    public void SpinWheel()
    {
        int slotsCount = _slotsKeeper.Slots.Length;
        int newSlot = Random.Range(0, slotsCount);
        Debug.Log(_slotsKeeper.Slots[newSlot].Value);

        int rotateAngle = (360 / slotsCount) * newSlot;
        rotateAngle = 360 * SPIN_COUNT + rotateAngle + 15;
        _wheel.DORotate(new Vector3(0, 0, rotateAngle), SPIN_DURATION, RotateMode.FastBeyond360).OnComplete(() => 
        {
            _rewardGiver.GiveReward(_slotsKeeper.Slots[newSlot].Value);
        });
    }
}
