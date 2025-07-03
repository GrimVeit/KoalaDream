using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomNameView : View
{
    [SerializeField] private List<RoomName> roomNames = new List<RoomName>();
    [SerializeField] private RoomNameNotification roomNameNotificationPrefab;
    [SerializeField] private Transform transformSpawn;
    [SerializeField] private Transform transformUp;
    [SerializeField] private Transform transformDown;

    private RoomNameNotification _currentRoomNameNotification;

    public void SetRoom(int id)
    {
        var roomName = GetRoomName(id);

        if(roomName == null)
        {
            Debug.LogWarning("Not found room name with id - " + id);
            return;
        }

        if(_currentRoomNameNotification != null) 
           _currentRoomNameNotification.Deactivate();

        _currentRoomNameNotification = Instantiate(roomNameNotificationPrefab, transformSpawn);
        _currentRoomNameNotification.transform.localPosition = transformUp.localPosition;
        _currentRoomNameNotification.SetData(roomName.NameRoom, roomName.DurationTyping, transformUp);
        _currentRoomNameNotification.Activate(transformDown);
    }

    private RoomName GetRoomName(int id)
    {
        return roomNames.FirstOrDefault(data => data.Id == id);
    }
}

[Serializable]
public class RoomName
{
    [SerializeField] private int id;
    [SerializeField] private string roomName;
    [SerializeField] private float durationTextTyping;

    public int Id => id;
    public string NameRoom => roomName;
    public float DurationTyping => durationTextTyping;
}
