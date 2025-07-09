using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerDeadZoneModel
{
    #region Output

    public event Action OnActivateDeadZone;

    public void ActivateDeadZone()
    {
        OnActivateDeadZone?.Invoke();
    }

    #endregion
}
