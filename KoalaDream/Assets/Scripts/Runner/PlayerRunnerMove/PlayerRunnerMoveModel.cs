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

        _touchSystemEventsProvider.OnStartTouch += StartUp;
        _touchSystemEventsProvider.OnStopTouch += StopUp;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _touchSystemEventsProvider.OnStartTouch -= StartUp;
        _touchSystemEventsProvider.OnStopTouch -= StopUp;
    }

    public void StartUp()
    {
        OnStartUp?.Invoke();
    }

    public void StopUp()
    {
        OnStopUp?.Invoke();
    }

    public void ApplyForceOffset(float amount, float duration)
    {
        OnApplyForceOffset?.Invoke(amount, duration);
    }

    #region Output

    public event Action OnStartUp;
    public event Action OnStopUp;

    public event Action<float, float> OnApplyForceOffset;

    #endregion
}
