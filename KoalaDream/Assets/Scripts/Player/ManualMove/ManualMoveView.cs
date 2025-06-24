using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMoveView : View
{
    [SerializeField] private MoveButton leftMove;
    [SerializeField] private MoveButton rightMove;

    private float currentDir;

    public void Initialize()
    {
        leftMove.OnDown += Down;
        rightMove.OnDown += Down;

        leftMove.OnUp += Up;
        rightMove.OnUp += Up;
    }

    public void Dispose()
    {
        leftMove.OnDown -= Down;
        rightMove.OnDown -= Down;

        leftMove.OnUp -= Up;
        rightMove.OnUp -= Up;
    }

    private void Down(float dir)
    {
        currentDir = dir;
        OnMove?.Invoke(currentDir);
    }

    private void Up(float dir)
    {
        if (currentDir == dir)
        {
            currentDir = 0;
            OnMove?.Invoke(0);
        }
    }

    #region Output

    public event Action<float> OnMove;

    #endregion
}
