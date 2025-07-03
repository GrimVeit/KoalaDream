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

    }

    public void Dispose()
    {

    }
}
