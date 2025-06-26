using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMarkerPresenter : IMoveMarkerProvider
{
    private readonly MoveMarkerModel _model;
    private readonly MoveMarkerView _view;

    public MoveMarkerPresenter(MoveMarkerModel model, MoveMarkerView view)
    {
        _model = model; _view = view;
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
        _model.OnActivate += _view.Activate;
        _model.OnDeactivate += _view.Deactivate;
    }

    public void DeactivateEvents()
    {
        _model.OnActivate -= _view.Activate;
        _model.OnDeactivate -= _view.Deactivate;
    }

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

public interface IMoveMarkerProvider
{
    public void Activate();
    public void Deactivate();
}
