using System;
using UnityEngine;

public class StartGameNotify : MonoBehaviour
{
    public static event Action OnGameStarted;

    private void OnEnable()
    {
        FlapInputNotify.OnFlaped += Notify;
    }
    private void OnDisable()
    {
        FlapInputNotify.OnFlaped -= Notify;
    }

    private void Notify()
    {
        OnGameStarted?.Invoke();
        enabled = false;
    }
}