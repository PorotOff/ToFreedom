using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PopupWithButton : Popup
{
    [SerializeField] private Button button;
    private CanvasGroup buttonCanvasGroup;
    private Transform buttonTransform;

    protected override void Awake()
    {
        base.Awake();

        buttonCanvasGroup = button.GetComponent<CanvasGroup>();
        buttonTransform = button.transform;
    }

    public override void Show()
    {
        base.Show();

        animationSequence
            .Join(buttonTransform
                .DOScale(new Vector3(1, 1, 1), duration)
                .From(new Vector3(0, 0, 0))
                .SetEase(Ease.OutElastic))
            .Join(buttonCanvasGroup
                .DOFade(1, duration)
                .SetEase(Ease.OutCirc));
    }

    public override void Hide()
    {
        base.Hide();

        animationSequence
            .Join(buttonTransform
                .DOScale(new Vector3(0, 0, 0), duration)
                .From(new Vector3(1, 1, 1))
                .SetEase(Ease.OutCirc))
            .Join(buttonCanvasGroup
                .DOFade(0, duration)
                .SetEase(Ease.OutCirc));
    }
}