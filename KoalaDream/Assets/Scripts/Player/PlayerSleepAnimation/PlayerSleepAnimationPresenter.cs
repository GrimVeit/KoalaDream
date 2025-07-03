using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSleepAnimationPresenter : IPlayerSleepAnimationProvider, IPlayerSleepAnimationEventsProvider
{
    private readonly PlayerSleepAnimationModel _model;
    private readonly PlayerSleepAnimationView _view;

    public PlayerSleepAnimationPresenter(PlayerSleepAnimationModel model, PlayerSleepAnimationView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        _view.OnEndActivate += _model.EndActivate;
        _view.OnEndDeactivate += _model.EndDeactivate;

        _model.OnActivate += _view.Activate;
        _model.OnDeactivate += _view.Deactivate;
    }

    private void DeactivateEvents()
    {
        _view.OnEndActivate -= _model.EndActivate;
        _view.OnEndDeactivate -= _model.EndDeactivate;

        _model.OnActivate -= _view.Activate;
        _model.OnDeactivate -= _view.Deactivate;
    }

    #region Output

    public event Action OnEndActivate
    {
        add => _model.OnEndActivate += value;
        remove => _model.OnEndActivate -= value;
    }

    public event Action OnEndDeactivate
    {
        add => _model.OnEndDeactivate += value;
        remove => _model.OnEndDeactivate -= value;
    }

    #endregion

    #region Input

    public void ActivateAnimation()
    {
        _model.Activate();
    }

    public void DeactivateAnimation()
    {
        _model.Deactivate();
    }

    #endregion
}

public interface IPlayerSleepAnimationEventsProvider
{
    public event Action OnEndActivate;
    public event Action OnEndDeactivate;
}

public interface IPlayerSleepAnimationProvider
{
    void ActivateAnimation();
    void DeactivateAnimation();
}
