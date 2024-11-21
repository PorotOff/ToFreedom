using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PageManagement : MonoBehaviour
{
    private static event Action OnPagesFinded;

    [SerializeField] private List<GameObject> pages;
    private static List<GameObject> staticPages;

    private void OnValidate()
    {
        staticPages = pages;
    }

    private void OnEnable()
    {
        OnPagesFinded += SerializePages;
    }
    private void OnDisable()
    {
        OnPagesFinded -= SerializePages;
    }

    private static List<GameObject> getAllPagesFromScene()
    {
        GameObject[] allGameObjectsOnScene;
        allGameObjectsOnScene = FindObjectsByType<GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        List<GameObject> pages = new List<GameObject>();

        foreach (GameObject obj in allGameObjectsOnScene)
        {
            if (obj.name.Contains("_Page"))
            {
                pages.Add(obj);
            }
        }

        return pages;
    }

    private void SerializePages()
    {
        pages = staticPages;
    }

    public static void FindPages()
    {
        staticPages = getAllPagesFromScene();

        OnPagesFinded?.Invoke();
    }

    public static List<GameObject> GetPages()
    {
        return new List<GameObject>(staticPages);
    }

    public static void EnableByIndex(int index)
    {
        disableAllPages();

        staticPages[index].SetActive(true);
    }

    private static void disableAllPages()
    {
        foreach (var page in staticPages)
        {
            page.SetActive(false);
        }
    }
}