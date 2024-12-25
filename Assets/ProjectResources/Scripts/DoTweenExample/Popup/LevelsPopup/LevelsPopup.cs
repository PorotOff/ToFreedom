using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class LevelsPopup : MonoBehaviour
{
    private CanvasGroup levelsPopupCanvasGroup;
    [SerializeField] private Transform buttonsContainer;

    private DG.Tweening.Sequence sequence;
    [SerializeField] private float mainDuration = 0.65f;

    [SerializeField] private float minHeight = -600f;

    private void Awake()
    {
        levelsPopupCanvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        Show();
    }
    private void OnDisable()
    {
        // Hide();
    }

    private void Show()
    {
        sequence?.Kill();

        sequence = DOTween.Sequence();

        sequence
            .Append(levelsPopupCanvasGroup
                .DOFade(1, mainDuration)
                .From(0)
                .SetEase(Ease.OutCubic))
            .Join(transform
                .DOLocalMoveY(0, mainDuration)
                .From(new Vector3(0, minHeight, 0))
                .SetEase(Ease.OutBack));

        // Собираем кнопки в список
        List<Transform> buttons = new List<Transform>();
        foreach (Transform btn in buttonsContainer)
        {
            buttons.Add(btn);
        }

        // Перемешиваем кнопки
        for (int i = 0; i < buttons.Count; i++)
        {
            int randomIndex = Random.Range(0, buttons.Count);
            Transform temp = buttons[i];
            buttons[i] = buttons[randomIndex];
            buttons[randomIndex] = temp;
        }

        // Анимация для каждой кнопки
        foreach (Transform btn in buttons)
        {
            float randomDuration = Random.Range(0.1f, 0.35f); // Случайная длительность
            float randomDelay = Random.Range(0.1f, 1f);       // Случайная задержка

            CanvasGroup buttonCanvasGroup = btn.GetComponent<CanvasGroup>();

            // Анимация масштаба
            btn.DOScale(1, randomDuration)
                .From(0)
                .SetEase(Ease.OutBounce)
                .SetDelay(randomDelay); // Устанавливаем задержку

            // Анимация прозрачности
            buttonCanvasGroup.DOFade(1, randomDuration)
                .From(0)
                .SetEase(Ease.OutCirc)
                .SetDelay(randomDelay); // Устанавливаем ту же задержку
        }
    }


    private void Hide()
    {
        sequence?.Kill();

        sequence = DOTween.Sequence();

        sequence
            .Append(levelsPopupCanvasGroup
                .DOFade(0, mainDuration)
                .From(1)
                .SetEase(Ease.OutCubic))
            .Join(transform
                .DOLocalMove(new Vector3(0, minHeight, 0), mainDuration)
                .From(0)
                .SetEase(Ease.OutBack));

        foreach (Transform btn in buttonsContainer)
        {
            float randomDuration = Random.Range(0.1f, 0.35f);

            CanvasGroup buttonCanvasGroup = btn.AddComponent<CanvasGroup>();

            sequence
                .Append(btn
                    .DOScale(0, randomDuration)
                    .From(1)
                    .SetEase(Ease.OutCirc))
                .Join(buttonCanvasGroup
                    .DOFade(0, randomDuration)
                    .From(1)
                    .SetEase(Ease.OutCirc));
        }
    }
}