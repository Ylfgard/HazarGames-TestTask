using TMPro;
using UnityEngine;

namespace Roulette
{
    internal class RouletteSlotsKeeper : MonoBehaviour
    {
        public RouletteSlot[] Slots { get; private set; }

        [SerializeField] private TextMeshProUGUI[] _slotsText;

        private void Awake()
        {
            Slots = new RouletteSlot[_slotsText.Length];
            for (int i = 0; i < _slotsText.Length; i++)
                Slots[i] = new RouletteSlot(_slotsText[i]);
        }
    }
}