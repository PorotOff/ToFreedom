using System;
using UnityEngine;

public abstract class PageTransition : MonoBehaviour
{
    [SerializeField] private int index;

    protected void go()
    {
        PageManagement.EnableByIndex(index);
    }

    public int GetIndex()
    {
        return index;
    }
    public void SetIndex(int index)
    {
        if (index < 0)
        {
            throw new Exception("Индекс не может быть отрицательным");
        }

        this.index = index;
    }
}