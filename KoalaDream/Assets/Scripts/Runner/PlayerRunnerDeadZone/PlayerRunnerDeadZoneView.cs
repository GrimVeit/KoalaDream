using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerDeadZoneView : View
{
    [SerializeField] private List<PlayerRunnerDeadZone> deadZones = new List<PlayerRunnerDeadZone>();

    public void Initialize()
    {
        deadZones.ForEach(dz => dz.OnActivateDeadZone += ActivateDeadZone);
    }

    public void Dispose()
    {
        deadZones.ForEach(dz => dz.OnActivateDeadZone -= ActivateDeadZone);
    }

    #region Output

    public event Action OnActivateDeadZone;

    private void ActivateDeadZone()
    {
        OnActivateDeadZone?.Invoke();
    }

    #endregion
}
