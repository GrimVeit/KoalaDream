using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] private float minLeftZ;
    [SerializeField] private float maxLeftZ;

    [SerializeField] private float minRightZ;
    [SerializeField] private float maxRightZ;

    [SerializeField] private float minDuration;
    [SerializeField] private float maxDuration;

    [SerializeField] private Transform leaf;

    private Sequence seq;

    private void Awake()
    {
        PlaySwing();
    }

    private void OnDestroy()
    {
        seq?.Kill();
    }

    private void PlaySwing()
    {
        float leftZ = Random.Range(minLeftZ, maxLeftZ);
        float rightZ = Random.Range(minRightZ, maxRightZ);

        float durationToLeft = Random.Range(minDuration, maxDuration);
        float durationToRight = Random.Range(minDuration, maxDuration);

        seq?.Kill();

        seq = DOTween.Sequence();
        seq.Append(leaf.DOLocalRotate(new Vector3(0, 0, leftZ), durationToLeft).SetEase(Ease.InOutSine))
            .Append(leaf.DOLocalRotate(new Vector3(0, 0, rightZ), durationToRight).SetEase(Ease.InOutSine))
            .OnComplete(() => PlaySwing());
    }
}
