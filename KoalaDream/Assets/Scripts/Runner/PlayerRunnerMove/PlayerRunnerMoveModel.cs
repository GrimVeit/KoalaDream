using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerMoveModel
{
    private readonly ITouchSystemEventsProvider _touchSystemEventsProvider;

    public PlayerRunnerMoveModel(ITouchSystemEventsProvider touchSystemEventsProvider)
    {
        _touchSystemEventsProvider = touchSystemEventsProvider;

        _touchSystemEventsProvider.OnStartTouch += StartTouch;
        _touchSystemEventsProvider.OnStopTouch += StopTouch;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _touchSystemEventsProvider.OnStartTouch -= StartTouch;
        _touchSystemEventsProvider.OnStopTouch -= StopTouch;
    }

    private void StartTouch()
    {
        OnStartTouch?.Invoke();
    }

    private void StopTouch()
    {
        OnStopTouch?.Invoke();
    }

    #region Output

    public event Action OnStartTouch;
    public event Action OnStopTouch;

    #endregion
}
