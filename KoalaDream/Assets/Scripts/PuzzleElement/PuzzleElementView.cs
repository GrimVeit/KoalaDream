using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleElementView : View
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private List<PuzzleElement> puzzleElements = new();

    [SerializeField] private PuzzleElement currentPuzzleElement;

    public void Initialize()
    {
        for (int i = 0; i < puzzleElements.Count; i++)
        {
            puzzleElements[i].OnGrabbing += OnGrabPuzzleElement;
            puzzleElements[i].Initialize();
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < puzzleElements.Count; i++)
        {
            puzzleElements[i].OnGrabbing -= OnGrabPuzzleElement;
            puzzleElements[i].Dispose();
        }
    }

    public void GrabPuzzleElement(PuzzleElement puzzleElement)
    {
        UngrabCurrentPuzzleElement();

        currentPuzzleElement = puzzleElement;

        currentPuzzleElement.OnStartMove += OnStartMove;
        currentPuzzleElement.OnMove += OnMove;
        currentPuzzleElement.OnEndMove += OnEndMove;
    }

    public void UngrabCurrentPuzzleElement()
    {
        if (currentPuzzleElement != null)
        {
            currentPuzzleElement.OnStartMove -= OnStartMove;
            currentPuzzleElement.OnMove -= OnMove;
            currentPuzzleElement.OnEndMove -= OnEndMove;

            Teleport();
        }
    }

    public void Teleport()
    {
        currentPuzzleElement.Teleport();
    }

    public void StartMove()
    {
        currentPuzzleElement.StartMove();
    }

    public void EndMove()
    {
        currentPuzzleElement.EndMove();
    }

    public void Move(Vector2 vector)
    {
        currentPuzzleElement.Move(vector);
    }

    #region Input

    public void OnGrabPuzzleElement(PuzzleElement puzzleElement)
    {
        OnGrabPuzzleElement_Action?.Invoke(puzzleElement);
    }

    private void OnMove(Vector2 vector)
    {
        OnMove_Action?.Invoke(vector / canvas.scaleFactor);
    }

    private void OnStartMove()
    {
        OnStartMove_Action?.Invoke();
    }

    private void OnEndMove(int id, Transform transform)
    {
        OnEndMove_Action?.Invoke(id, transform);
    }

    public event Action<PuzzleElement> OnGrabPuzzleElement_Action;

    public event Action<Vector2> OnMove_Action;

    public event Action OnStartMove_Action;

    public event Action<int, Transform> OnEndMove_Action;

    #endregion
}
