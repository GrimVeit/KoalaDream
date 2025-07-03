using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveView : View
{
    [SerializeField] private PlayerMove playerMove;

    [SerializeField] private List<Transform> transformsTeleports = new List<Transform>();

    public void Initialize()
    {
        playerMove.OnPositionChanged += ChangePosition;
        playerMove.OnChangeDirection += ChangeDirection;
    }

    public void Dispose()
    {
        playerMove.OnPositionChanged -= ChangePosition;
        playerMove.OnChangeDirection -= ChangeDirection;
    }

    #region Output

    public event Action<float> OnChangePosition;
    public event Action<int> OnChangeDirection;

    private void ChangePosition(float pos)
    {
        OnChangePosition?.Invoke(pos);
    }

    private void ChangeDirection(int pos)
    {
        OnChangeDirection?.Invoke(pos);
    }

    #endregion

    #region Input

    public void Move(float direction)
    {
        playerMove.Move(direction);
    }

    public void Teleport(int id)
    {
        playerMove.Teleport(transformsTeleports[id].position.x);
    }

    #endregion
}
