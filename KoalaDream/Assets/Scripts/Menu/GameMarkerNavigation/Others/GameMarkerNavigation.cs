using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameMarkerNavigation : MotionBase
{
    [SerializeField] private Transform transformMarker;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform transformZero;
    [SerializeField] private Transform transformOne;
    [SerializeField] private Vector3 rotateZero;
    [SerializeField] private Vector3 rotateOne;
    [SerializeField] private float minDuration;
    [SerializeField] private float maxDuration;

    private Sequence sequence;

    public override void Activate()
    {
        sequence?.Kill();

        sequence = DOTween.Sequence();

        float randomDuration = Random.Range(minDuration, maxDuration);

        sequence
            .Append(transformMarker.DOLocalMove(transformOne.localPosition, randomDuration))
            .Join(transformMarker.DOLocalRotate(rotateOne, randomDuration))
            .Join(spriteRenderer.DOFade(1, randomDuration));
    }

    public override void Deactivate()
    {
        sequence?.Kill();

        sequence = DOTween.Sequence();

        float randomDuration = Random.Range(minDuration, maxDuration);

        sequence
            .Append(transformMarker.DOLocalMove(transformZero.localPosition, randomDuration))
            .Join(transformMarker.DOLocalRotate(rotateZero, randomDuration))
            .Join(spriteRenderer.DOFade(0, randomDuration));
    }
}
