using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMovePresenter
{
    private readonly ManualMoveModel _model;
    private readonly ManualMoveView _view;

    public ManualMovePresenter(ManualMoveModel model, ManualMoveView view)
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
        _view.OnMove += _model.Move;
    }

    private void DeactivateEvents()
    {
        _view.OnMove -= _model.Move;
    }

    #region Output

    public event Action<float> OnMove
    {
        add => _model.OnMove += value;
        remove => _model.OnMove -= value;
    }

    #endregion
}
