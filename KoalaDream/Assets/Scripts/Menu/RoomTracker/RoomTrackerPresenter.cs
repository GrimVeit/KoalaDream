using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrackerPresenter : IRoomTrackerProvider, IRoomTrackerEventsProvider
{
    private readonly RoomTrackerModel _model;
    private readonly RoomTrackerView _view;

    public RoomTrackerPresenter(RoomTrackerModel model, RoomTrackerView view)
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

        _model.Dispose();
        _view.Dispose();
    }

    private void ActivateEvents()
    {
        _model.OnCalculateRooms += _view.Calculate;

        _view.OnSelectRoom += _model.SetRoom;
    }

    private void DeactivateEvents()
    {
        _model.OnCalculateRooms -= _view.Calculate;

        _view.OnSelectRoom -= _model.SetRoom;
    }



    #region Output

    public event Action<int> OnActivatedRoom
    {
        add => _model.OnActivatedRoom += value;
        remove => _model.OnActivatedRoom -= value;
    }

    public event Action<int> OnDeactivatedRoom
    {
        add => _model.OnDeactivatedRoom += value;
        remove => _model.OnDeactivatedRoom -= value;
    }

    #endregion


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

public interface IRoomTrackerProvider
{
    public void Activate();
    public void Deactivate();
}

public interface IRoomTrackerEventsProvider
{
    public event Action<int> OnActivatedRoom;
    public event Action<int> OnDeactivatedRoom;
}
