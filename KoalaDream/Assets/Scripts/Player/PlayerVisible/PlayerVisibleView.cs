using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisibleView : View
{
    [SerializeField] private GameObject player;

    public void Show()
    {
        player.SetActive(true);
    }

    public void Hide()
    {
        player.SetActive(false);
    }
}
