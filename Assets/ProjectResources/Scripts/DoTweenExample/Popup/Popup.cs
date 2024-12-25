using DG.Tweening;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private CanvasGroup body;
    private RectTransform bodyRectTransform;

    [SerializeField] private float popupStartPositionY;

    protected float duration = 1f;

    protected Sequence animationSequence;

    protected virtual void Awake()
    {
        bodyRectTransform = body.GetComponent<RectTransform>();

        gameObject.SetActive(false);
    }

    public virtual void Show()
    {
        bodyRectTransform.anchoredPosition = new Vector3(0, popupStartPositionY, 0);

        animationSequence?.Kill();
        animationSequence = DOTween.Sequence();
        animationSequence
            .Append(bodyRectTransform
                .DOAnchorPosY(0, duration)
                .SetEase(Ease.OutCirc))
            .Join(body
                .DOFade(1, duration)
                .SetEase(Ease.OutCirc));
    }

    public virtual void Hide()
    {
        animationSequence?.Kill();
        animationSequence = DOTween.Sequence();
        animationSequence
            .Append(bodyRectTransform
                .DOAnchorPosY(popupStartPositionY, duration)
                .SetEase(Ease.OutCirc))
            .Join(body
                .DOFade(0, duration)
                .SetEase(Ease.OutCirc)
                .OnComplete(() => gameObject.SetActive(false)));
    }
}