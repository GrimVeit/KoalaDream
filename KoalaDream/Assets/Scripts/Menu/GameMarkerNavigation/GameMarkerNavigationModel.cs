using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMarkerNavigationModel
{
    private readonly IRoomTrackerEventsProvider _roomTrackerEventsProvider;

    private bool isActive = true;

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
        if(!isActive) return;

        OnActivatedMarkers?.Invoke(roomId);
    }

    private void DeactivateMarkers(int roomId)
    {
        if (!isActive) return;

        OnDeactivatedMarkers?.Invoke(roomId);
    }

    #region Input

    public void Activate()
    {
        isActive = true;

        OnActivatedMarkers?.Invoke(_roomTrackerEventsProvider.GetCurrentRoom());
    }

    public void AllDeactivate()
    {
        isActive = false;

        OnAllDeactivatedMarkers?.Invoke();
    }

    #endregion

    #region Output

    public event Action<int> OnActivatedMarkers;
    public event Action<int> OnDeactivatedMarkers;

    public event Action OnAllDeactivatedMarkers;

    #endregion
}
