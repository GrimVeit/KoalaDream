using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private int dir;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDown?.Invoke(dir);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnUp?.Invoke(dir);
    }

    #region Input

    public event Action<float> OnDown;
    public event Action<float> OnUp;

    #endregion
}
