using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBorder : MonoBehaviour
{
    public Vector3 Position => borderPosition.position;
    [SerializeField] private Transform borderPosition; 

    [SerializeField] private RoomPoint leftPoint;
    [SerializeField] private RoomPoint rightPoint;

    public void Calculate(Vector3 playerPosition)
    {
        float distToLeft = (playerPosition - leftPoint.Position).sqrMagnitude;
        float distToRight = (playerPosition - rightPoint.Position).sqrMagnitude;
        
        if(distToLeft < distToRight)
        {
            OnSelectRoom?.Invoke(leftPoint.RoomId);
        }
        else
        {
            OnSelectRoom?.Invoke(rightPoint.RoomId);
        }
    }

    #region Output

    public event Action<int> OnSelectRoom;

    #endregion
}
