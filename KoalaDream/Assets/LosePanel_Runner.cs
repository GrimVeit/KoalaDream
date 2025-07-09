using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class LosePanel_Runner : MovePanel
{
    [SerializeField] private AnimationFrame animationFrame;

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        animationFrame.Activate(3);
    }
}
