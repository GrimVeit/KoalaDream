using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Puzzles", menuName = "Game/Puzzles/Group")]
public class PuzzlesGroup : ScriptableObject
{
    [SerializeField] private List<Puzzles> puzzles = new List<Puzzles>();

    public Puzzles GetPuzzles(int id)
    {
        return puzzles.FirstOrDefault(data => data.Id == id);
    }
}
