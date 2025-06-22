using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMarkerNavigationPresenter
{
    private readonly GameMarkerNavigationModel _model;
    private readonly GameMarkerNavigationView _view;

    public GameMarkerNavigationPresenter(GameMarkerNavigationModel model, GameMarkerNavigationView view)
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
        _model.OnActivatedMarkers += _view.Activate;
        _model.OnDeactivatedMarkers += _view.Deactivate;
    }

    private void DeactivateEvents()
    {
        _model.OnActivatedMarkers -= _view.Activate;
        _model.OnDeactivatedMarkers -= _view.Deactivate;
    }
}
