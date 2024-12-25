using DG.Tweening;
using UnityEngine;

public class SimpleUpDown : MonoBehaviour
{
    private float duration = 0.65f;
    [SerializeField] private float maxHeight = 1f;
    Vector3 startPosition;

    Sequence livitateAnimationSequence;
    Tween tween;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void OnEnable()
    {
        CreateLivitateAnimation();
    }
    private void OnDisable()
    {
        StopLivitate();
    }

    private void CreateLivitateAnimation()
    {
        livitateAnimationSequence = DOTween.Sequence();

        livitateAnimationSequence
            .OnStart(() => Debug.Log("Секвенция была запущена"))
            .Append(transform
                .DOMoveY(startPosition.y + maxHeight, duration)
                .OnStart(() => Debug.Log("Движение по Y ВВЕРХ"))
                .From(startPosition)
                .SetEase(Ease.InOutCubic))
                .OnComplete(() => Debug.Log("Движение по Y ВВЕРХ ЗАКОНЧЕНО"))
                .OnKill(() => Debug.Log("Анимация ВВЕРХ была уничтожена"))
            .Append(transform
                .DOMoveY(startPosition.y, duration)
                .OnStart(() => Debug.Log("Движение по Y ВНИЗ"))
                .SetEase(Ease.InOutCubic))
                .OnComplete(() => Debug.Log("Движение по Y ВНИЗ ЗАКОНЧЕНО"))
                .OnKill(() => Debug.Log("Анимация ВНИЗ была уничтожена"))
            .SetLoops(-1, LoopType.Restart)
            .OnKill(() => Debug.Log("Секвенция была уничтожена"));

        // tween = transform.DOMoveY(maxHeight, duration).SetRelative().SetEase(Ease.OutCubic).SetLoops(-1, LoopType.Yoyo);
    }

    public void PlayLivitate()
    {
        livitateAnimationSequence.Play();
    }

    public void PauseLivitate()
    {
        livitateAnimationSequence.Pause();
    }

    public void RestartLivivtate()
    {
        livitateAnimationSequence.Restart();
    }

    public void StopLivitate()
    {
        livitateAnimationSequence.Kill();
    }
}