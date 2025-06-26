using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMarkerModel
{
    public void Activate()
    {
        OnActivate?.Invoke();
    }

    public void Deactivate()
    {
        OnDeactivate?.Invoke();
    }

    public event Action OnActivate;
    public event Action OnDeactivate;
}
