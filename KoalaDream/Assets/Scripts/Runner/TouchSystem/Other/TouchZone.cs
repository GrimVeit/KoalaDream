using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchZone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        OnStartTouch?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnStopTouch?.Invoke();
    }

    #region Output

    public event Action OnStartTouch;
    public event Action OnStopTouch;

    #endregion
}
