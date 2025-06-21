using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMarkerNavigationView : View
{
    [SerializeField] private List<PlayerMarkerNavigation> playerMarkerNavigations = new List<PlayerMarkerNavigation>();

    public void ActivateMarker(int id)
    {
        var marker = GetPlayerMarkerNavigation(id);

        if(marker == null)
        {
            Debug.LogWarning("Not found player marker navigation visual with id - " + id);
            return;
        }

        marker.Activate();
    }

    public void DeactivateMarker(int id)
    {
        var marker = GetPlayerMarkerNavigation(id);

        if (marker == null)
        {
            Debug.LogWarning("Not found player marker navigation visual with id - " + id);
            return;
        }

        marker.Deactivate();
    }

    private PlayerMarkerNavigation GetPlayerMarkerNavigation(int id)
    {
        return playerMarkerNavigations.FirstOrDefault(data => data.RoomId == id);
    }
}
