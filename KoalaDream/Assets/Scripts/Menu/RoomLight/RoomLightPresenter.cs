using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLightPresenter
{
    private readonly RoomLightModel _model;
    private readonly RoomLightView _view;

    public RoomLightPresenter(RoomLightModel model, RoomLightView view)
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
        _model.OnActivateRoomLight += _view.Activate;
        _model.OnDeactivateRoomLight += _view.Deactivate;
    }

    private void DeactivateEvents()
    {
        _model.OnActivateRoomLight -= _view.Activate;
        _model.OnDeactivateRoomLight -= _view.Deactivate;
    }
}

