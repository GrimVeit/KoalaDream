using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedGameAccessModel
{
    #region Output

    public event Action OnActivateGame;

    #endregion

    #region Input

    public void ActivateGame()
    {
        OnActivateGame?.Invoke();
    }

    #endregion
}
