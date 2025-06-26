using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MoveMarker : MotionBase
{
    public int MarkerId => markerId;

    [SerializeField] private int markerId;
    [SerializeField] private Transform transformMarker;
    [SerializeField] private Image image;
    [SerializeField] private Transform transformZero;
    [SerializeField] private Transform transformOne;
    [SerializeField] private Vector3 rotateZero;
    [SerializeField] private Vector3 rotateOne;
    [SerializeField] private float duration;

    private Sequence sequence;

    public override void Activate()
    {
        sequence?.Kill();

        sequence = DOTween.Sequence();

        sequence
            .Append(transformMarker.DOLocalMove(transformOne.localPosition, duration))
            .Join(transformMarker.DOLocalRotate(rotateOne, duration))
            .Join(image.DOFade(1, duration));
    }

    public override void Deactivate()
    {
        sequence?.Kill();

        sequence = DOTween.Sequence();

        sequence
            .Append(transformMarker.DOLocalMove(transformZero.localPosition, duration))
            .Join(transformMarker.DOLocalRotate(rotateZero, duration))
            .Join(image.DOFade(0, duration));
    }
}
