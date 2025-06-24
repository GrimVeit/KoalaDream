using System;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveView : View
{
    [SerializeField] private List<AutoMoveButton> autoMoves = new List<AutoMoveButton>();

    public void Initialize()
    {
        autoMoves.ForEach(m => m.OnTarget += Target);
    }

    public void Dispose()
    {
        autoMoves.ForEach(m => m.OnTarget -= Target);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Target(-14);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Target(14);
        }
    }

    #region Output

    public event Action<float> OnTarget;

    public void Target(float target)
    {
        OnTarget?.Invoke(target);
    }

    #endregion
}
