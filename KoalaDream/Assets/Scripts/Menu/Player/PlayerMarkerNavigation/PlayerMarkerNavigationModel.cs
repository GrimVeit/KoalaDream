using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarkerNavigationModel
{
    private readonly IRoomTrackerEventsProvider _roomTrackerEventsProvider;

    public PlayerMarkerNavigationModel(IRoomTrackerEventsProvider roomTrackerEventsProvider)
    {
        _roomTrackerEventsProvider = roomTrackerEventsProvider;

        _roomTrackerEventsProvider.OnActivatedRoom += DeactivateMarker;
        _roomTrackerEventsProvider.OnDeactivatedRoom += ActivateMarker;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _roomTrackerEventsProvider.OnActivatedRoom -= DeactivateMarker;
        _roomTrackerEventsProvider.OnDeactivatedRoom -= ActivateMarker;
    }

    private void ActivateMarker(int roomId)
    {
        OnActivateMarker?.Invoke(roomId);
    }

    private void DeactivateMarker(int roomId)
    {
        OnDeactivateMarker?.Invoke(roomId);
    }

    #region Output

    public event Action<int> OnActivateMarker;
    public event Action<int> OnDeactivateMarker;

    #endregion
}
