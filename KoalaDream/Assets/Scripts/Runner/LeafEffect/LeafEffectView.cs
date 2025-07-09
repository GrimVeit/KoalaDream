using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class LeafEffectView : View
{
    [SerializeField] private List<LeafPath> leafPaths = new List<LeafPath>();
    [SerializeField] private float moveDurationMin;
    [SerializeField] private float moveDurationMax;

    [SerializeField] private Transform transformLeaf;

    private Tween tweenMove;

    public void ActivateLeaf()
    {
        var path = GetRandomLeafPath();

        transformLeaf.localPosition = path.Start.localPosition;
        transformLeaf.eulerAngles = path.Rotation;

        tweenMove?.Kill();

        transformLeaf.DOScale(1, 0.2f);

        Debug.Log("PATH: " + leafPaths.IndexOf(path));

        tweenMove = transformLeaf.DOLocalMove(path.End.localPosition, GetRandomDuration()).OnComplete(() => transformLeaf.DOScale(0, 0.2f));
    }

    public void DeactivateLeaf()
    {
        tweenMove?.Kill();

        transformLeaf.DOScale(0, 0.2f);
    }

    private float GetRandomDuration()
    {
        return Random.Range(moveDurationMin, moveDurationMax);
    }

    private LeafPath GetRandomLeafPath()
    {
        return leafPaths[Random.Range(0, leafPaths.Count)];
    }
}

[Serializable]
public class LeafPath
{
    [SerializeField] private Transform transformStart;
    [SerializeField] private Transform transformEnd;
    [SerializeField] private Vector3 rotation;

    public Transform Start => transformStart;
    public Transform End => transformEnd;
    public Vector3 Rotation => rotation;
}
