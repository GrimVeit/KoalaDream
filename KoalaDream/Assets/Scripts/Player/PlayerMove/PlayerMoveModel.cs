using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveModel
{
    #region Output

    public event Action<float> OnChangePosition;
    public event Action<float> OnMove;

    #endregion

    #region Input

    public void Move(float direction)
    {
        OnMove?.Invoke(direction);
    }

    public void ChangePosition(float position)
    {
        OnChangePosition?.Invoke(position);
    }

    #endregion
}
