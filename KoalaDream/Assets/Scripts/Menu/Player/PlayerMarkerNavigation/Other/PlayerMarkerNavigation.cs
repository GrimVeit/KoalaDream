using DG.Tweening;
using UnityEngine;

public class PlayerMarkerNavigation : MotionBase
{
    public int RoomId => roomId;

    [SerializeField] private int roomId;
    [SerializeField] private Transform transformMarker;
    [SerializeField] private SpriteRenderer spriteRenderer;
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
            .Join(spriteRenderer.DOFade(1, duration));
    }

    public override void Deactivate()
    {
        sequence?.Kill();

        sequence = DOTween.Sequence();

        sequence
            .Append(transformMarker.DOLocalMove(transformZero.localPosition, duration))
            .Join(transformMarker.DOLocalRotate(rotateZero, duration))
            .Join(spriteRenderer.DOFade(0, duration));
    }
}
