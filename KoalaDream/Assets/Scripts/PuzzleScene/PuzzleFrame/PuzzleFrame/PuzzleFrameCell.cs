using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleFrameCell : MonoBehaviour, ICell
{
    public int IdCell() => Id;

    [SerializeField] private int Id;
    [SerializeField] private Image image;
    [SerializeField] private Color colorActivate;

    public void Set()
    {
        OnAddPuzzle?.Invoke(Id);
    }

    public void Activate()
    {
        image.color = colorActivate;
    }

    public event Action<int> OnAddPuzzle;
}

public interface ICell
{
    public int IdCell();
    public void Set();
}
