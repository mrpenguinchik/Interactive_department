using UnityEngine;
using DG.Tweening;

public class Feedback : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _scalePercent;

    [NaughtyAttributes.Button]
    public void SmoothScale()
    {
        transform.DOScale(Vector3.one * _scalePercent, _duration)
            .OnComplete(() =>
            {
                transform.DOScale(Vector3.one, _duration);
            });
    }
}
