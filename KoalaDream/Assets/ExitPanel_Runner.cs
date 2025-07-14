using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanel_Runner : MovePanel
{
    [SerializeField] private AnimationFrame animationFrame;

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        animationFrame.Activate(5);
    }
}
