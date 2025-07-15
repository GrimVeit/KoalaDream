using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSystemPresenter : ITouchSystemEventsProvider, ITouchSystemProvider
{
    private readonly TouchSystemModel _model;
    private readonly TouchSystemView _view;

    public TouchSystemPresenter(TouchSystemModel model, TouchSystemView view)
    {
        _model = model; _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _view.Dispose();
    }

    private void ActivateEvents()
    {
        _view.OnStartTouch += _model.StartTouch;
        _view.OnStopTouch += _model.StopTouch;
    }

    private void DeactivateEvents()
    {
        _view.OnStartTouch -= _model.StartTouch;
        _view.OnStopTouch -= _model.StopTouch;
    }

    #region Output

    public event Action OnStartTouch
    {
        add => _model.OnStartTouch += value;
        remove => _model.OnStartTouch -= value;
    }

    public event Action OnStopTouch
    {
        add => _model.OnStopTouch += value;
        remove => _model.OnStopTouch -= value;
    }

    #endregion

    #region Input

    public void Activate()
    {
        _model.Activate();
    }

    public void Deactivate()
    {
        _model.Deactivate();
    }

    #endregion
}

public interface ITouchSystemProvider
{
    void Activate();
    void Deactivate();
}

public interface ITouchSystemEventsProvider
{
    public event Action OnStartTouch;
    public event Action OnStopTouch;
}
