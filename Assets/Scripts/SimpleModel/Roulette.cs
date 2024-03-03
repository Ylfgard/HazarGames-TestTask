using DG.Tweening;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    private const int SpinCount = 3;
    private const float SpinDuration = 5;

    [SerializeField] private RouletteSlotsKeeper _slotsKeeper;
    [SerializeField] private RewardGiver _rewardGiver;
    [SerializeField] private Transform _wheel;

    public void SpinWheel()
    {
        int slotsCount = _slotsKeeper.Slots.Length;
        int newSlot = Random.Range(0, slotsCount);
        Debug.Log(_slotsKeeper.Slots[newSlot].Value);

        int rotateAngle = (360 / slotsCount) * newSlot;
        rotateAngle = 360 * SpinCount + rotateAngle + 15;
        _wheel.DORotate(new Vector3(0, 0, rotateAngle), SpinDuration, RotateMode.FastBeyond360).OnComplete(() => 
        {
            _rewardGiver.GiveReward(_slotsKeeper.Slots[newSlot].Value);
        });
    }
}
