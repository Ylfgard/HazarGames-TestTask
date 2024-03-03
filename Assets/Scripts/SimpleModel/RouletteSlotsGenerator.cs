using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RouletteSlotsGenerator : MonoBehaviour
{
    private const int ValuesCount = 20;

    private int[] _values;

    private void Awake()
    {
        _values = new int[ValuesCount];
        
        for (int i = 1; i <= ValuesCount; i++)
            _values[i - 1] = i * 5;
    }

    public void GenerateSlots(RouletteSlot[] slots)
    {
        if (slots.Length > ValuesCount)
        {
            Debug.LogError("Wrongs slots count!");
            return;
        }

        List<int> values = _values.ToList();
        for (int i = 0; i < slots.Length; i++)
        {
            int index = Random.Range(0, values.Count);
            slots[i].SetValue(values[index]);
            values.Remove(values[index]);
        }
    }
}
