using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoMoveButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform target;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTarget?.Invoke(target.position.x);
    }

    #region Input

    public event Action<float> OnTarget;

    #endregion
}
