using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartGameInputNotify : MonoBehaviour, IPointerDownHandler
{
    public static event Action OnGameStarted;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnGameStarted?.Invoke();
        gameObject.SetActive(false);
    }
}