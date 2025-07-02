using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleFrame : MonoBehaviour
{
    public int Id => id;

    [SerializeField] private int id;

    [SerializeField] private List<PuzzleFrameCell> cells = new();

    [Header("Scale")]
    [SerializeField] private Transform transformPuzzlesParent;
    [SerializeField] private Vector3 scaleMaxPuzParent;
    [SerializeField] private float durationScaleParentPuzOn;
    [SerializeField] private float durationScaleParentPuzOff;

    [Header("Black")]
    [SerializeField] private Image imageBlack;
    [SerializeField] private float durationBlackOff;

    private int needCount => cells.Count;
    private int currentCount = 0;

    private Sequence sequenceScale;

    public void Initialize()
    {
        cells.ForEach(data => data.OnAddPuzzle += Set);
    }

    public void Dispose()
    {
        cells.ForEach(data => data.OnAddPuzzle -= Set);
    }

    public void ShowScale()
    {
        sequenceScale?.Kill();

        sequenceScale = DOTween.Sequence();

        sequenceScale
            .Append(transformPuzzlesParent.DOScale(scaleMaxPuzParent, durationScaleParentPuzOn))
            .Append(transformPuzzlesParent.DOScale(Vector3.one, durationScaleParentPuzOff));
    }

    //public void HideBlack()
    //{
    //    imageBlack.DOFade(0, durationBlackOff);
    //}

    private void Set(int id)
    {
        Debug.Log("ADD: " + id);

        cells[id].Activate();

        currentCount += 1;

        if(currentCount == needCount)
        {
            Debug.Log("WINNNNNN");
            OnCompletePuzzle?.Invoke(Id);
        }
    }

    #region Output

    public event Action<int> OnCompletePuzzle;

    #endregion
}
