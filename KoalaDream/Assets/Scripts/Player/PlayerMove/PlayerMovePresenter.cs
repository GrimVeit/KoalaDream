using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePresenter : IPlayerMoveProvider, IPlayerMoveEventsProvider, IPlayerDirectionEventsProvider
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
        _view.OnChangeDirection += _model.ChangeDirection;

        _model.OnMove += _view.Move;
        _model.OnTeleport += _view.Teleport;
    }

    private void DeactivateEvents()
    {
        _view.OnChangePosition -= _model.ChangePosition;
        _view.OnChangeDirection -= _model.ChangeDirection;

        _model.OnMove -= _view.Move;
        _model.OnTeleport -= _view.Teleport;
    }

    #region Output

    public event Action<float> OnChangePosition
    {
        add => _model.OnChangePosition += value;
        remove => _model.OnChangePosition -= value;
    }

    public event Action<int> OnChangeDirection
    {
        add => _model.OnChangeDirection += value;
        remove => _model.OnChangeDirection -= value;
    }

    #endregion


    #region Input

    public void Move(float direction)
    {
        _model.Move(direction);
    }

    public void Teleport(int id)
    {
        _model.Teleport(id);
    }

    #endregion
}

public interface IPlayerMoveEventsProvider
{
    public event Action<float> OnChangePosition;
}

public interface IPlayerDirectionEventsProvider
{
    public event Action<int> OnChangeDirection;
}

public interface IPlayerMoveProvider
{
    void Move(float dir);
    void Teleport(int id);
}