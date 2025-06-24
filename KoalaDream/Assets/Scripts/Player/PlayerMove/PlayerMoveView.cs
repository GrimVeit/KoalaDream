using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveView : View
{
    [SerializeField] private PlayerMove playerMove;

    public void Initialize()
    {
        playerMove.OnPositionChanged += ChangePosition; 
    }

    public void Dispose()
    {
        playerMove.OnPositionChanged -= ChangePosition;
    }

    #region Output

    public event Action<float> OnChangePosition; 

    private void ChangePosition(float pos)
    {
        OnChangePosition?.Invoke(pos);
    }

    #endregion

    #region Input

    public void Move(float direction)
    {
        playerMove.Move(direction);
    }

    #endregion
}
