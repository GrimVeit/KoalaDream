using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMarkerNavigationModel
{
    private readonly IRoomTrackerEventsProvider _roomTrackerEventsProvider;

    public GameMarkerNavigationModel(IRoomTrackerEventsProvider roomTrackerEventsProvider)
    {
        _roomTrackerEventsProvider = roomTrackerEventsProvider;

        _roomTrackerEventsProvider.OnActivatedRoom += ActivateMarkers;
        _roomTrackerEventsProvider.OnDeactivatedRoom += DeactivateMarkers;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _roomTrackerEventsProvider.OnActivatedRoom -= ActivateMarkers;
        _roomTrackerEventsProvider.OnDeactivatedRoom -= DeactivateMarkers;
    }

    private void ActivateMarkers(int roomId)
    {
        OnActivatedMarkers?.Invoke(roomId);
    }

    private void DeactivateMarkers(int roomId)
    {
        OnDeactivatedMarkers?.Invoke(roomId);
    }

    #region Output

    public event Action<int> OnActivatedMarkers;
    public event Action<int> OnDeactivatedMarkers;

    #endregion
}
