using System;
using UnityEngine;

public class PuzzleElementModel
{
    public event Action<Puzzles> OnSelectPuzzles;

    public event Action OnUngrabCurrentPuzzleElement;
    public event Action<PuzzleElement> OnGrabPuzzleElement;

    public event Action OnStartMove;
    public event Action<Vector2> OnMove;
    public event Action OnEndMove;
    public event Action OnDestroy;

    private ISoundProvider _soundProvider;
    private IStorePicturesSelectEventsProvider _storePicturesSelectEventsProvider;
    private PuzzlesGroup _puzzlesGroup;

    public PuzzleElementModel(ISoundProvider soundProvider, IStorePicturesSelectEventsProvider storePicturesSelectEventsProvider, PuzzlesGroup puzzlesGroup)
    {
        _soundProvider = soundProvider;
        _storePicturesSelectEventsProvider = storePicturesSelectEventsProvider;
        _puzzlesGroup = puzzlesGroup;

        _storePicturesSelectEventsProvider.OnSelectPicture += SelectPuzzles;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storePicturesSelectEventsProvider.OnSelectPicture -= SelectPuzzles;
    }

    private void SelectPuzzles(Picture picture)
    {
        var puzzles = _puzzlesGroup.GetPuzzles(picture.Id);

        OnSelectPuzzles?.Invoke(puzzles);
    }

    public void GrabPuzzleElement(PuzzleElement puzzleElement)
    {
        OnUngrabCurrentPuzzleElement?.Invoke();

        OnGrabPuzzleElement?.Invoke(puzzleElement);
    }

    public void StartMove()
    {
        OnStartMove?.Invoke();
    }

    public void Move(Vector2 vector)
    {
        OnMove?.Invoke(vector);
    }

    public void EndMove(int id, Transform transform)
    {
        Collider2D collider = Physics2D.OverlapPoint(transform.position);

        if (collider != null)
        {
            if(collider.gameObject.TryGetComponent(out ICell cell))
            {
                if(cell.IdCell() == id)
                {
                    cell.Set();
                    OnDestroy?.Invoke();
                    return;
                }
            }
        }

        OnEndMove?.Invoke();
    }
}
