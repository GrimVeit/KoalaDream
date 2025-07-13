using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSoundView : View
{
    [SerializeField] private PlayerAnimationSound animationSound;

    public void Initialize()
    {
        animationSound.OnActivateSound += ActivateSound;
    }

    public void Dispose()
    {
        animationSound.OnActivateSound -= ActivateSound;
    }

    #region Output

    public event Action<string> OnActivateSound;
    
    private void ActivateSound(string id)
    {
        OnActivateSound?.Invoke(id);
    }

    #endregion
}
