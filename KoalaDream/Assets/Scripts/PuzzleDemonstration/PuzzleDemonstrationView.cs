using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleDemonstrationView : View
{
    [SerializeField] private Image imagePicture;
    [SerializeField] private List<PuzzleDemonstration> puzzleDemonstrations = new List<PuzzleDemonstration>();

    public void SelectPuzzle(int id)
    {
        var demo = GetPuzzleDemonstration(id);

        if(demo == null)
        {
            Debug.LogWarning("Not found puzzle demonstration with id - " + id);
            return;
        }

        imagePicture.sprite = demo.Sprite;
    }

    private PuzzleDemonstration GetPuzzleDemonstration(int id)
    {
        return puzzleDemonstrations.FirstOrDefault(data => data.Id == id);
    }
}

[Serializable]
public class PuzzleDemonstration
{
    [SerializeField] private int id;
    [SerializeField] private Sprite sprite;

    public int Id => id;
    public Sprite Sprite => sprite;
}
