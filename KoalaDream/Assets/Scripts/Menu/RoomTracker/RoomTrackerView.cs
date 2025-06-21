using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrackerView : View
{
    [SerializeField] private List<RoomBorder> roomBorders = new();
    [SerializeField] private Transform player;

    public void Initialize()
    {
        roomBorders.ForEach(data => data.OnSelectRoom += SelectRoom);
    }

    public void Dispose()
    {
        roomBorders.ForEach(data => data.OnSelectRoom -= SelectRoom);
    }

    public void Calculate()
    {
        RoomBorder roomBorder = null;
        float minLength = float.MaxValue;

        for (int i = 0; i < roomBorders.Count; i++)
        {
            float distance = GetDistanceForBorder(roomBorders[i]);

            if(distance < minLength)
            {
                roomBorder = roomBorders[i];
                minLength = distance;
            }
        }

        roomBorder.Calculate(player.position);
    }

    private float GetDistanceForBorder(RoomBorder border)
    {
        return (player.position - border.Position).sqrMagnitude;
    }

    #region Output

    public event Action<int> OnSelectRoom;

    private void SelectRoom(int roomId)
    {
        OnSelectRoom?.Invoke(roomId);
    }

    #endregion
}
