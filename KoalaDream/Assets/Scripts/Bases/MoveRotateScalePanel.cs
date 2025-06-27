using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveRotateScalePanel : MoveRotatePanel
{
    [SerializeField] protected Vector3 scaleFrom;
    [SerializeField] protected Vector3 scaleTo;

    protected Tween scaleRotate;

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        scaleRotate = panel.transform.DOScale(scaleTo, time);
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();

        scaleRotate = panel.transform.DOScale(scaleFrom, time);
    }

    public override void Dispose()
    {
        base.Dispose();

        scaleRotate?.Kill();
    }
}
