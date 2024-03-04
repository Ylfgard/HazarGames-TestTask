using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RewardView : MonoBehaviour
{
    [SerializeField] private Image _image;

    private Vector3 _scorePosition;

    public void Init(Vector3 scorePosition)
    {
        _scorePosition = scorePosition;
    }

    public void Show(Sprite sprite, Vector3 position, float showDuration, float hideDelay, float hideDuration)
    {
        _image.sprite = sprite;
        transform.position = position;
        transform.DOScale(1, showDuration).OnComplete(
                () => StartCoroutine(HideReward(hideDelay, hideDuration))
            );
    }

    private IEnumerator HideReward(float delay, float duration)
    {
        yield return new WaitForSeconds(delay);
        transform.DOMove(_scorePosition, duration);
        transform.DOScale(0, duration);
    }
}
