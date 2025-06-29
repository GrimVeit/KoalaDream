using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleElementModel
{
    public event Action OnUngrabCurrentPuzzleElement;
    public event Action<PuzzleElement> OnGrabPuzzleElement;

    public event Action OnStartMove;
    public event Action<Vector2> OnMove;
    public event Action OnEndMove;
    public event Action OnTeleporting;

    private bool isActive = true;

    private ISoundProvider _soundProvider;

    public PuzzleElementModel(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void GrabPuzzleElement(PuzzleElement puzzleElement)
    {
        OnUngrabCurrentPuzzleElement?.Invoke();

        //soundProvider.PlayOneShot("ChipGrab");

        OnGrabPuzzleElement?.Invoke(puzzleElement);
    }

    public void StartMove()
    {
        if (!isActive) return;

        OnStartMove?.Invoke();
    }

    public void Move(Vector2 vector)
    {
        if (!isActive) return;

        OnMove?.Invoke(vector);
    }

    public void EndMove(int id, Transform transform)
    {
        if (!isActive) return;

        Collider2D collider = Physics2D.OverlapPoint(transform.position);

        if (collider != null)
        {
            Debug.Log(collider.gameObject.name);

            //if(collider.gameObject.TryGetComponent(out ICell cell))
            //{
            //    cell.AddChip(id, chip, transform.position);
            //    Teleport();
            //    return;
            //}
        }

        _soundProvider.PlayOneShot("Whoosh");
        OnEndMove?.Invoke();
    }

    public void Teleport()
    {
        OnTeleporting?.Invoke();
    }

    public void Activate()
    {
        isActive = true;
    }


    public void Deactivate()
    {
        isActive = false;
    }
}
