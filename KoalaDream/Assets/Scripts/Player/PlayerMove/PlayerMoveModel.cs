using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveModel
{
    private int currentDirection = 0;

    #region Output

    public event Action<float> OnChangePosition;
    public event Action<int> OnChangeDirection;

    public event Action<float> OnMove;
    public event Action<int> OnTeleport;

    #endregion

    #region Input

    public void Move(float direction)
    {
        OnMove?.Invoke(direction);
    }

    public void Teleport(int id)
    {
        OnTeleport?.Invoke(id);
    }

    public void ChangePosition(float position)
    {
        OnChangePosition?.Invoke(position);
    }

    public void ChangeDirection(int pos)
    {
        if(currentDirection == pos) return;

        currentDirection = pos;

        OnChangeDirection?.Invoke(currentDirection);
    }

    #endregion
}
