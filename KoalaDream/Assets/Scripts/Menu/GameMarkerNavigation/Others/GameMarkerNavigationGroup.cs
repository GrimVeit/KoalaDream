using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMarkerNavigationGroup : MonoBehaviour
{
    public int RoomId => roomId;

    [SerializeField] private int roomId;

    [SerializeField] private List<GameMarkerNavigation> gameMarkerNavigations = new List<GameMarkerNavigation>();

    public void Activate()
    {
        gameMarkerNavigations.ForEach(x => x.Activate());
    }

    public void Deactivate()
    {
        gameMarkerNavigations.ForEach(x => x.Deactivate());
    }
}
