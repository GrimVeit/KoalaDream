using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNameModel
{
    private readonly IRoomTrackerEventsProvider _roomTrackerEventsProvider;

    public RoomNameModel(IRoomTrackerEventsProvider roomTrackerEventsProvider)
    {
        _roomTrackerEventsProvider = roomTrackerEventsProvider;

        _roomTrackerEventsProvider.OnActivatedRoom += SetRoom;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _roomTrackerEventsProvider.OnActivatedRoom -= SetRoom;
    }

    private void SetRoom(int index)
    {
        OnSetRoom?.Invoke(index);
    }
    #region Output

    public event Action<int> OnSetRoom;

    #endregion
}
