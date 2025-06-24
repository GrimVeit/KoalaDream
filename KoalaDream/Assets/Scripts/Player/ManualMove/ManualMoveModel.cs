using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMoveModel
{
    #region Output

    public event Action<float> OnMove;

    #endregion

    #region Input

    public void Move(float dir)
    {
        OnMove?.Invoke(dir);
    }

    #endregion
}
