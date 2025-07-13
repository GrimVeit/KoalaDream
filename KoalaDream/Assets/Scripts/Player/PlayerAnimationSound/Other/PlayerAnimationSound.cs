using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSound : MonoBehaviour
{

    public void ActivateSound(string id)
    {
        OnActivateSound?.Invoke(id);
    }

    #region Output

    public event Action<string> OnActivateSound;

    #endregion
}
