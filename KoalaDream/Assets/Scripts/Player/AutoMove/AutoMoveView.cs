using System;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveView : View
{
    [SerializeField] private List<AutoMoveButton> autoMoves = new List<AutoMoveButton>();
    [SerializeField] private List<Transform> moveOthersTransforms = new List<Transform>();

    public void Initialize()
    {
        autoMoves.ForEach(m => m.OnTarget += Target);
    }

    public void Dispose()
    {
        autoMoves.ForEach(m => m.OnTarget -= Target);
    }

    #region Output

    public event Action<float> OnTarget;

    public void Target(float target)
    {
        OnTarget?.Invoke(target);
    }

    #endregion

    #region Input

    public void Move(int index)
    {
        Target(moveOthersTransforms[index].position.x);
    }

    #endregion
}
