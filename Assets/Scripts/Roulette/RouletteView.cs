using DG.Tweening;
using UnityEngine;

namespace Roulette
{
    internal class RouletteView : MonoBehaviour
    {
        [SerializeField] private Transform _wheel;

        public void SpinWheel(int rotateAngle, float spinDuration)
        {
            _wheel.DORotate(new Vector3(0, 0, rotateAngle), spinDuration, RotateMode.FastBeyond360);
        }
    }
}