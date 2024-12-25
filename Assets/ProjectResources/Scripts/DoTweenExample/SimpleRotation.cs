using DG.Tweening;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    [SerializeField] private float duration;

    private Tween tweenAnimation;

    private void OnEnable()
    {
        Rotate();
    }

    private void OnDisable()
    {
        tweenAnimation.Kill();
    }

    public void Rotate()
    {
        tweenAnimation = transform.DORotate(new Vector3(0, 0, 360), duration, RotateMode.FastBeyond360).From(new Vector3(0, 0, 0)).SetEase(Ease.OutCubic).SetLoops(-1, LoopType.Yoyo);
    }
}