using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovePresenter : IAutoMoveEventsProvider
{
    private readonly AutoMoveModel _model;
    private readonly AutoMoveView _view;

    public AutoMovePresenter(AutoMoveModel model, AutoMoveView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _model.Initialize();
        _view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _model.Dispose();
        _view.Dispose();
    }

    private void ActivateEvents()
    {
        _view.OnTarget += _model.MoveTo;
    }

    private void DeactivateEvents()
    {
        _view.OnTarget -= _model.MoveTo;
    }

    #region Output

    public event Action OnStartMove
    {
        add => _model.OnStartMove += value;
        remove => _model.OnStartMove -= value;
    }

    public event Action OnEndMove
    {
        add => _model.OnStopMove += value;
        remove => _model.OnStopMove -= value;
    }

    #endregion

    #region Input

    public void Move(int index)
    {
        _view.Move(index);
    }

    #endregion
}

public interface IAutoMoveEventsProvider
{
    public event Action OnStartMove;
    public event Action OnEndMove;
}

public interface IAutoMoveProvider
{
    public void Move(int index);
}
