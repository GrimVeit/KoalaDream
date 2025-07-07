using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorConverter
{
    public static Vector3 ToUnityVector(this System.Numerics.Vector3 vector)
    {
        return new Vector3(vector.X, vector.Y, vector.Z);
    }

    public static System.Numerics.Vector3 ToSystemVector(this Vector3 vector)
    {
        return new System.Numerics.Vector3(vector.x, vector.y, vector.z);
    }
}
