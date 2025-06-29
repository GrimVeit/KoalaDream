using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles
{
    [SerializeField] private int id;

    public int Id => id;
    public List<PuzzleElement> puzzleElements = new();
}
