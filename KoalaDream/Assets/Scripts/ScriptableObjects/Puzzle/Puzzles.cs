using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Puzzles", menuName = "Game/Puzzles/New")]
public class Puzzles : ScriptableObject
{
    [SerializeField] private int id;

    public int Id => id;
    public List<PuzzleElement> puzzleElements = new();
}
