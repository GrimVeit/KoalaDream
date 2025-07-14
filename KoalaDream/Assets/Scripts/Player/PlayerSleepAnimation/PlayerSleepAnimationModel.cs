using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSleepAnimationModel
{
    private readonly ISoundProvider _soundProvider;

    public PlayerSleepAnimationModel(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

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
        OnEndDeactivate?.Invoke();
    }

    public void SitToTheBedroom()
    {
        _soundProvider.PlayOneShot("SitBedroom");
    }

    public void Hrap()
    {
        _soundProvider.PlayOneShot("Hrap");
    }
    
    #region Output

    public event Action OnActivate;
    public event Action OnDeactivate;

    public event Action OnEndActivate;
    public event Action OnEndDeactivate;

    #endregion
}
