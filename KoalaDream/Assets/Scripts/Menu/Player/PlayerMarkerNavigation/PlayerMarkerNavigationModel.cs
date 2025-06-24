using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarkerNavigationModel
{
    private readonly IRoomTrackerEventsProvider _roomTrackerEventsProvider;

    private bool isActive = true;

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
        if(!isActive) return;

        OnActivateMarker?.Invoke(roomId);
    }

    private void DeactivateMarker(int roomId)
    {
        if (!isActive) return;

        OnDeactivateMarker?.Invoke(roomId);
    }

    #region Input

    public void AllDeactivate()
    {
        isActive = false;

        OnAllDeactivates?.Invoke();
    }

    public void AllDeactivatesExcept()
    {
        isActive = true;

        OnAllActivatesExcept?.Invoke(_roomTrackerEventsProvider.GetCurrentRoom());
    }

    #endregion

    #region Output

    public event Action<int> OnActivateMarker;
    public event Action<int> OnDeactivateMarker;

    public event Action<int> OnAllActivatesExcept;
    public event Action OnAllDeactivates;

    #endregion
}
