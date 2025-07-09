using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerMovePresenter : IPlayerRunnerMoveProvider, IPlayerRunnerForceProvider, IPlayerRunnerMoveFreezeProvider
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

        _model.OnFreeze += _view.Freeze;
        _model.OnUnfreeze += _view.Unfreeze;

        _model.OnApplyForceOffset += _view.ApplyOffset;
    }

    private void DeactivateEvents()
    {
        _model.OnStartUp -= _view.StartUp;
        _model.OnStopUp -= _view.StopUp;

        _model.OnFreeze -= _view.Freeze;
        _model.OnUnfreeze -= _view.Unfreeze;

        _model.OnApplyForceOffset -= _view.ApplyOffset;
    }

    #region Input

    public void StartUp()
    {
        _model.StartUp();
    }

    public void StopUp()
    {
        _model.StopUp();
    }

    public void Freeze()
    {
        _model.Freeze();
    }

    public void Unfreeze()
    {
        _model.Unfreeze();
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

public interface IPlayerRunnerMoveFreezeProvider
{
    void Freeze();
    void Unfreeze();
}

public interface IPlayerRunnerForceProvider
{
    public void ApplyForceOffset(float amount, float duration);
}