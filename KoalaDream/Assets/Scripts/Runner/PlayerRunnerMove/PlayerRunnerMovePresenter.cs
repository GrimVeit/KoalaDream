using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerMovePresenter : IPlayerRunnerMoveProvider, IPlayerRunnerForceProvider, IPlayerRunnerActivatorEventsProvider, IPlayerRunnerActivatorProvider
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
        _model.OnStartUp += _view.StartUp;
        _model.OnStopUp += _view.StopUp;

        _model.OnApplyForceOffset += _view.ApplyOffset;
    }

    private void DeactivateEvents()
    {
        _model.OnStartUp -= _view.StartUp;
        _model.OnStopUp -= _view.StopUp;

        _model.OnApplyForceOffset -= _view.ApplyOffset;
    }

    #region Output

    public event Action OnActivate
    {
        add => _view.OnActivateToStart += value;
        remove => _view.OnActivateToStart -= value;
    }

    #endregion

    #region Input

    public void StartUp()
    {
        _model.StartUp();
    }

    public void StopUp()
    {
        _model.StopUp();
    }

    public void Activate()
    {
        _view.MoveToStart();
    }

    public void ApplyForceOffset(float amount, float duration)
    {
        _model.ApplyForceOffset(amount, duration);
    }

    #endregion
}

public interface IPlayerRunnerMoveProvider
{
    void StartUp();
    void StopUp();
}

public interface IPlayerRunnerActivatorProvider
{
    void Activate();
}

public interface IPlayerRunnerActivatorEventsProvider
{
    public event Action OnActivate;
}

public interface IPlayerRunnerForceProvider
{
    public void ApplyForceOffset(float amount, float duration);
}