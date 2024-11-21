using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlapInputNotify : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static event Action OnFlaped;
    public static event Action OnSqueekFlaped;
    public static event Action OnUnflapped;

    [Header("Squeek chance settings")]
    private SqueekChanceModel squeekChanceModel;
    [SerializeField, Range(0, 100)] private int squeekChance;
    private int minSqueekChance = 0;
    private int maxSqueekChance = 100;

    private void Awake()
    {
        squeekChanceModel = new SqueekChanceModel(squeekChance, minSqueekChance, maxSqueekChance);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        FlapNotify();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UnflapNotify();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) FlapNotify();
        if (Input.GetKeyDown(KeyCode.UpArrow)) FlapNotify();

        if (Input.GetKeyUp(KeyCode.Space)) UnflapNotify();
        if (Input.GetKeyUp(KeyCode.UpArrow)) UnflapNotify();
    }

    private void FlapNotify()
    {
        if (squeekChanceModel.IsSqueekChance())
        {
            OnSqueekFlaped?.Invoke();
            return;
        }

        OnFlaped?.Invoke();
    }
    private void UnflapNotify()
    {
        OnUnflapped?.Invoke();
    }
}