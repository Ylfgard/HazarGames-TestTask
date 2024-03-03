using TMPro;
using UnityEngine;

public class RouletteSlotsKeeper : MonoBehaviour
{
    public RouletteSlot[] Slots { get; private set; }

    [SerializeField] private RouletteSlotsGenerator _generator;
    [SerializeField] private TextMeshProUGUI[] _slotsText;

    private void Awake()
    {
        Slots = new RouletteSlot[_slotsText.Length];
        for (int i = 0; i < _slotsText.Length; i++)
            Slots[i] = new RouletteSlot(_slotsText[i]);
    }

    private void Start()
    {
        GenerateSlots();
    }

    public void GenerateSlots()
    {
        _generator.GenerateSlots(Slots);
    }
}