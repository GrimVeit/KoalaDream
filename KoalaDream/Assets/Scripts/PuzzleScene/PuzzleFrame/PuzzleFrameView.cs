using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleFrameView : View
{
    [SerializeField] private List<PuzzleFrame> frames = new List<PuzzleFrame>();
    [SerializeField] private Transform transformSpawn;

    private PuzzleFrame _currentPuzzleFrame;

    public void SelectFrame(int frameIndex)
    {
        var puzzleFramePrefab = GetPuzzleFrame(frameIndex);

        if(puzzleFramePrefab == null)
        {
            Debug.Log("Not found puzzle frame with id - " + frameIndex);
            return;
        }

        _currentPuzzleFrame = Instantiate(puzzleFramePrefab, transformSpawn);
        _currentPuzzleFrame.OnCompletePuzzle += CompletePuzzle;
        _currentPuzzleFrame.transform.localPosition = Vector3.zero;
        _currentPuzzleFrame.Initialize();
    }
    public void Dispose()
    {
        if( _currentPuzzleFrame == null) return;

        _currentPuzzleFrame.OnCompletePuzzle -= CompletePuzzle;

        _currentPuzzleFrame.Dispose();
    }

    public void ShowScale()
    {
        _currentPuzzleFrame?.ShowScale();
    }

    //public void HideBlack()
    //{
    //    _currentPuzzleFrame?.HideBlack();
    //}

    private PuzzleFrame GetPuzzleFrame(int id)
    {
        return frames.FirstOrDefault(data => data.Id == id);
    }

    #region Output

    public event Action<int> OnCompletePuzzle;

    private void CompletePuzzle(int id)
    {
        OnCompletePuzzle?.Invoke(id);
    }

    #endregion
}
