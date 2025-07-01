using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDemonstrationModel
{
    private readonly IStorePicturesSelectEventsProvider _storePicturesSelectEventsProvider;

    public PuzzleDemonstrationModel(IStorePicturesSelectEventsProvider storePicturesSelectEventsProvider)
    {
        _storePicturesSelectEventsProvider = storePicturesSelectEventsProvider;

        _storePicturesSelectEventsProvider.OnSelectPicture += SelectPuzzle;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storePicturesSelectEventsProvider.OnSelectPicture -= SelectPuzzle;
    }

    private void SelectPuzzle(Picture picture)
    {
        OnSelectPuzzle?.Invoke(picture.Id);
    }

    #region Output

    public event Action<int> OnSelectPuzzle;

    #endregion
}
