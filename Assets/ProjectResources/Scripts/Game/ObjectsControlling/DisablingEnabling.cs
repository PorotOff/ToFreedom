using System.Collections.Generic;
using UnityEngine;

public class DisablingEnabling : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjectsToToggle;

    private void OnEnable()
    {
        StartGameNotify.OnGameStarted += Disable;
        GameOverNotify.OnGameOver += Enable;
    }
    private void OnDisable()
    {
        StartGameNotify.OnGameStarted -= Disable;
        GameOverNotify.OnGameOver -= Enable;
    }

    private void Disable()
    {
        EnableAllObjects(false);
    }
    private void Enable()
    {
        EnableAllObjects(true);
    }

    private void EnableAllObjects(bool isEnable)
    {
        foreach (var obj in gameObjectsToToggle)
        {
            obj.SetActive(isEnable);
        }
    }
}