using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSleepAnimationModel
{
    public void Activate()
    {
        OnActivate?.Invoke();
    }

    public void Deactivate()
    {
        OnDeactivate?.Invoke();
    }


    public void EndActivate()
    {
        OnEndActivate?.Invoke();
    }

    public void EndDeactivate()
    {
        OnEndActivate?.Invoke();
    }
    
    #region Output

    public event Action OnActivate;
    public event Action OnDeactivate;

    public event Action OnEndActivate;
    public event Action OnEndDeactivate;

    #endregion
}
