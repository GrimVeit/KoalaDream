using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePresenter : IPlayerMoveProvider, IPlayerMoveEventsProvider
{
    private readonly PlayerMoveModel _model;
    private readonly PlayerMoveView _view;

    public PlayerMovePresenter(PlayerMoveModel model, PlayerMoveView view)
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
        _view.OnChangePosition += _model.ChangePosition;

        _model.OnMove += _view.Move;
    }

    private void DeactivateEvents()
    {
        _view.OnChangePosition -= _model.ChangePosition;

        _model.OnMove -= _view.Move;
    }

    #region Output

    public event Action<float> OnChangePosition
    {
        add => _model.OnChangePosition += value;
        remove => _model.OnChangePosition -= value;
    }

    #endregion


    #region Input

    public void Move(float direction)
    {
        _model.Move(direction);
    }

    #endregion
}

public interface IPlayerMoveEventsProvider
{
    public event Action<float> OnChangePosition;
}

public interface IPlayerMoveProvider
{
    void Move(float dir);
}