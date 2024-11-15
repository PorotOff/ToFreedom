using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputNotify : MonoBehaviour, IPointerDownHandler
{
    public static event Action OnTouchedScreen;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouchedScreen?.Invoke();
    }
}