using System;
using System.Collections;
using System.Collections.Generic;

public class RoomTrackerModel
{
    private int _currentRoomId = -1;

    private IEnumerator tracker;


    public void Activate()
    {
        if(tracker is not null) Coroutines.Stop(tracker);

        tracker = RoomTracker();
        Coroutines.Start(tracker);
    }

    public void Deactivate()
    {
        OnDeactivatedRoom?.Invoke(_currentRoomId);
        _currentRoomId = -1;

        if (tracker is not null) Coroutines.Stop(tracker);
    }

    public void Dispose()
    {
        if (tracker is not null) Coroutines.Stop(tracker);
    }


    private IEnumerator RoomTracker()
    {
        while (true)
        {
            OnCalculateRooms?.Invoke();
            yield return null;
        }
    }

    #region Output

    public event Action OnCalculateRooms;
    public event Action<int> OnActivatedRoom;
    public event Action<int> OnDeactivatedRoom;

    public int GetCurrentRoom()
    {
        return _currentRoomId;
    }

    #endregion

    #region Input

    public void SetRoom(int roomId)
    {
        if (_currentRoomId == roomId) 
            return;

        if(_currentRoomId != -1)
            OnDeactivatedRoom?.Invoke(_currentRoomId);

        UnityEngine.Debug.Log("ROOM: " + roomId);
        _currentRoomId = roomId;
        OnActivatedRoom?.Invoke(roomId);
    }

    #endregion
}
