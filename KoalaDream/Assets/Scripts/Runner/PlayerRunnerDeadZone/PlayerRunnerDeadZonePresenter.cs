using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerDeadZonePresenter : IPlayerRunnerDeadZoneEventsProvider
{
    private readonly PlayerRunnerDeadZoneModel _model;
    private readonly PlayerRunnerDeadZoneView _view;

    public PlayerRunnerDeadZonePresenter(PlayerRunnerDeadZoneModel model, PlayerRunnerDeadZoneView view)
    {
        _model = model;
        _view = view;
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
        _view.OnActivateDeadZone += _model.ActivateDeadZone;
    }

    private void DeactivateEvents()
    {
        _view.OnActivateDeadZone -= _model.ActivateDeadZone;
    }

    #region Output

    public event Action OnActivateDeadZone
    {
        add => _model.OnActivateDeadZone += value;
        remove => _model.OnActivateDeadZone -= value;
    }

    #endregion
}

public interface IPlayerRunnerDeadZoneEventsProvider
{
    public event Action OnActivateDeadZone;
}
