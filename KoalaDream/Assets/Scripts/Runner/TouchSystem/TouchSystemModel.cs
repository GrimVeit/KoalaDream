using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSystemModel
{
    private bool isActive = true;

    #region Output

    public event Action OnStartTouch;
    public event Action OnStopTouch;

    #endregion

    #region Input

    public void StartTouch()
    {
        if(!isActive) return;

        OnStartTouch?.Invoke();
    }

    public void StopTouch()
    {
        if(!isActive) return;

        OnStopTouch?.Invoke();
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        StopTouch();

        isActive = false;
    }

    #endregion
}
