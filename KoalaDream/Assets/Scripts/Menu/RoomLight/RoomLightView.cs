using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomLightView : View
{
    [SerializeField] private List<RoomLight> lights = new List<RoomLight>();
    [SerializeField] private float duration;

    public void Activate(int id)
    {
        var light = GetRoomLight(id);

        if(light == null)
        {
            Debug.LogWarning("Not found room light visual with id - " + light);
            return;
        }

        light.Activate(duration);
    }

    public void Deactivate(int id)
    {
        var light = GetRoomLight(id);

        if (light == null)
        {
            Debug.LogWarning("Not found room light visual with id - " + light);
            return;
        }

        light.Deactivate(duration);
    }

    private RoomLight GetRoomLight(int id)
    {
        return lights.FirstOrDefault(data => data.RoomId == id);
    }
}
