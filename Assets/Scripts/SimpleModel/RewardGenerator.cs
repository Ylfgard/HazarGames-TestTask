using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardGenerator : MonoBehaviour
{
    public Sprite CurReward => _rewards[_curIndex];

    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _rewards;

    private List<int> _indexes = new List<int>();
    private int _curIndex;

    private void Awake()
    {
        for (int i  = 0; i < _rewards.Length; i++)
            _indexes.Add(i);
        
        _curIndex = Random.Range(0, _indexes.Count);
        _indexes.Remove(_curIndex);
        
        _image.sprite = _rewards[_curIndex];
    }

    public void GenerateReward()
    {
        int i = _curIndex;
        _curIndex = _indexes[Random.Range(0, _indexes.Count)];
        _indexes.Remove(_curIndex);
        _indexes.Add(i);

        _image.sprite = _rewards[_curIndex];
    }
}
