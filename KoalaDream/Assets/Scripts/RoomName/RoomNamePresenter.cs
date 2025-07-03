using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNamePresenter
{
    private readonly RoomNameModel _model;
    private readonly RoomNameView _view;

    public RoomNamePresenter(RoomNameModel model, RoomNameView view)
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
        _model.OnSetRoom += _view.SetRoom;
    }

    private void DeactivateEvents()
    {
        _model.OnSetRoom -= _view.SetRoom;
    }
}
