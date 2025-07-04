using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSystemView : View
{
    [SerializeField] private TouchZone touchZone;

    public void Initialize()
    {
        touchZone.OnStartTouch += StartTouch;
        touchZone.OnStopTouch += StopTouch;
    }

    public void Dispose()
    {
        touchZone.OnStartTouch -= StartTouch;
        touchZone.OnStopTouch -= StopTouch;
    }

    #region Output

    public event Action OnStartTouch;
    public event Action OnStopTouch;

    private void StartTouch()
    {
        OnStartTouch?.Invoke();
    }

    private void StopTouch()
    {
        OnStopTouch?.Invoke();
    }

    #endregion
}
