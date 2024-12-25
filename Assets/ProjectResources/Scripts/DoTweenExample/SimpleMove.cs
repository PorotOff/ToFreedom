using DG.Tweening;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;
    [SerializeField] private float duration;

    private Vector3 startPosition;

    private Tween tweenAnimation;

    private void OnEnable()
    {
        startPosition = transform.position;

        Move();
    }

    private void OnDisable()
    {
        tweenAnimation.Complete();
    }

    public void Move()
    {
        transform.position = startPosition;

        tweenAnimation = transform.DOMove(targetPosition.position, duration).From(startPosition).SetEase(Ease.OutCirc).SetLoops(3, LoopType.Yoyo);
    }
}