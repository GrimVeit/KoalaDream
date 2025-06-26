using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMarkerView : View
{
    [SerializeField] private List<MoveMarker> moveMarkers = new List<MoveMarker>();

    public void Activate()
    {
        moveMarkers.ForEach(m => m.Activate());
    }

    public void Deactivate()
    {
        moveMarkers.ForEach(m => m.Deactivate());
    }
}
