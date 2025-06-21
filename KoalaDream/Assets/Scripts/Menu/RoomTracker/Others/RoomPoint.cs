using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPoint : MonoBehaviour
{
    [SerializeField] private int roomId;
    [SerializeField] private Transform transformPosition;

    public int RoomId => roomId;
    public Vector3 Position => transformPosition.position;
}
