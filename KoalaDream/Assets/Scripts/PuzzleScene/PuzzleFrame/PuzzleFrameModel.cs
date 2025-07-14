using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFrameModel
{
    private readonly IStorePicturesSelectEventsProvider _storePicturesSelectEventsProvider;

    private readonly ISoundProvider _soundProvider;

    public PuzzleFrameModel(IStorePicturesSelectEventsProvider storePicturesSelectEventsProvider, ISoundProvider soundProvider)
    {
        _storePicturesSelectEventsProvider = storePicturesSelectEventsProvider;
        _soundProvider = soundProvider;

        _storePicturesSelectEventsProvider.OnSelectPicture += SelectFrame;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storePicturesSelectEventsProvider.OnSelectPicture -= SelectFrame;
    }

    #region Output

    public event Action<int> OnSelectFrame;

    public event Action OnShowScale;

    public event Action<int> OnCompletePuzzle;

    private void SelectFrame(Picture picture)
    {
        OnSelectFrame?.Invoke(picture.Id);
    }

    #endregion

    #region Input

    public void CompletePuzzle(int id)
    {
        OnCompletePuzzle?.Invoke(id);
    }

    public void ShowScale()
    {
        _soundProvider.PlayOneShot("Puzzle_Complete");

        OnShowScale?.Invoke();
    }

    #endregion
}
