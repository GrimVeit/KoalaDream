using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameMarkerNavigationView : View
{
    [SerializeField] private List<GameMarkerNavigationGroup> navigationGroups = new List<GameMarkerNavigationGroup>();

    public void Activate(int roomId)
    {
        var group = GetNavigationGroup(roomId);

        if(group == null)
        {
            Debug.LogWarning("Not found game marker navigation group with id - " + roomId);
            return;
        }

        group.Activate();
    }

    public void Deactivate(int roomId)
    {
        var group = GetNavigationGroup(roomId);

        if (group == null)
        {
            Debug.LogWarning("Not found game marker navigation group with id - " + roomId);
            return;
        }

        group.Deactivate();
    }

    public void AllDeactivates()
    {
        navigationGroups.ForEach(data => data.Deactivate());
    }

    private GameMarkerNavigationGroup GetNavigationGroup(int roomId)
    {
        return navigationGroups.FirstOrDefault(x => x.RoomId == roomId);
    }
}
