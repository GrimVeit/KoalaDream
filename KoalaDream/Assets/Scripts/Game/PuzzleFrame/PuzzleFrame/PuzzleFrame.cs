using System;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFrame : MonoBehaviour
{
    public int Id => id;

    [SerializeField] private int id;

    [SerializeField] private List<PuzzleFrameCell> cells = new();
    
    private int needCount => cells.Count;
    private int currentCount = 0;

    public void Initialize()
    {
        cells.ForEach(data => data.OnAddPuzzle += Set);
    }

    public void Dispose()
    {
        cells.ForEach(data => data.OnAddPuzzle -= Set);
    }

    private void Set(int id)
    {
        Debug.Log("ADD: " + id);

        cells[id].Activate();

        currentCount += 1;

        if(currentCount == needCount)
        {
            Debug.Log("WINNNNNN");
        }
    }

    #region Output

    public event Action OnAddPuzzle;

    #endregion
}
