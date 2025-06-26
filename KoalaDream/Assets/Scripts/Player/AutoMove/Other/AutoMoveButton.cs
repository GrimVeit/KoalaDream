using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoMoveButton : MonoBehaviour
{
    [SerializeField] private Transform target;

    public void PointerDown()
    {
        OnTarget?.Invoke(target.position.x);
    }

    #region Input

    public event Action<float> OnTarget;

    #endregion
}
