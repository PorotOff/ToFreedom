using System;
using UnityEngine;

public class GameOverNotify : MonoBehaviour
{
    public static event Action OnGameOver;

    private void OnEnable()
    {
        HealthModel.OnDie += Notify;
    }
    private void OnDisable()
    {
        HealthModel.OnDie -= Notify;
    }

    private void Notify()
    {
        OnGameOver?.Invoke();
    }
}