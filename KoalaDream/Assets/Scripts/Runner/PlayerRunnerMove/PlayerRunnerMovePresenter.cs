using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerMovePresenter
{
    private readonly PlayerRunnerMoveModel _model;
    private readonly PlayerRunnerMoveView _view;

    public PlayerRunnerMovePresenter(PlayerRunnerMoveModel model, PlayerRunnerMoveView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _model.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _model.Dispose();
    }

    private void ActivateEvents()
    {
        _model.OnStartTouch += _view.StartTouch;
        _model.OnStopTouch += _view.StopTouch;
    }

    private void DeactivateEvents()
    {
        _model.OnStartTouch -= _view.StartTouch;
        _model.OnStopTouch -= _view.StopTouch;
    }
}
