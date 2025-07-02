using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisibleModel
{
    public event Action OnShowPlayer;
    public event Action OnHidePlayer;

    public void Show()
    {
        OnShowPlayer?.Invoke();
    }

    public void Hide()
    {
        OnHidePlayer?.Invoke();
    }
}
