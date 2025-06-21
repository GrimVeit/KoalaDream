using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLightModel
{
    private readonly IRoomTrackerEventsProvider _roomTrackerEventsProvider;

    public RoomLightModel(IRoomTrackerEventsProvider roomTrackerEventsProvider)
    {
        _roomTrackerEventsProvider = roomTrackerEventsProvider;

        _roomTrackerEventsProvider.OnActivatedRoom += ActivateRoomLight;
        _roomTrackerEventsProvider.OnDeactivatedRoom += DeactivateRoomLight;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _roomTrackerEventsProvider.OnActivatedRoom -= ActivateRoomLight;
        _roomTrackerEventsProvider.OnDeactivatedRoom -= DeactivateRoomLight;
    }

    private void ActivateRoomLight(int roomId)
    {
        OnActivateRoomLight?.Invoke(roomId);
    }

    private void DeactivateRoomLight(int roomId)
    {
        OnDeactivateRoomLight?.Invoke(roomId);
    }

    #region Output

    public event Action<int> OnActivateRoomLight;
    public event Action<int> OnDeactivateRoomLight;

    #endregion
}
