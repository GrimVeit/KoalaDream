using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveRotatePanel : MovePanel
{
    [SerializeField] protected Vector3 rotateFrom;
    [SerializeField] protected Vector3 rotateTo;

    protected Tween tweenRotate;

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        tweenRotate = panel.transform.DOLocalRotate(rotateTo, time);
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();

        tweenRotate = panel.transform.DOLocalRotate(rotateFrom, time);
    }

    public override void Dispose()
    {
        base.Dispose();

        tweenRotate?.Kill();
    }
}
