using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFrameModel
{
    private readonly IStorePicturesSelectEventsProvider _storePicturesSelectEventsProvider;

    public PuzzleFrameModel(IStorePicturesSelectEventsProvider storePicturesSelectEventsProvider)
    {
        _storePicturesSelectEventsProvider = storePicturesSelectEventsProvider;

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

    private void SelectFrame(Picture picture)
    {
        OnSelectFrame?.Invoke(picture.Id);
    }

    #endregion

    #region Input



    #endregion
}
