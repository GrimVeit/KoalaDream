using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarkerNavigationPresenter
{
    private readonly PlayerMarkerNavigationModel _model;
    private readonly PlayerMarkerNavigationView _view;

    public PlayerMarkerNavigationPresenter(PlayerMarkerNavigationModel model, PlayerMarkerNavigationView view)
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
        _model.OnActivateMarker += _view.ActivateMarker;
        _model.OnDeactivateMarker += _view.DeactivateMarker;
    }

    private void DeactivateEvents()
    {
        _model.OnActivateMarker -= _view.ActivateMarker;
        _model.OnDeactivateMarker -= _view.DeactivateMarker;
    }
}
