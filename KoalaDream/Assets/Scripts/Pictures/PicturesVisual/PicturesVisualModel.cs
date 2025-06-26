using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturesVisualModel
{
    private readonly IStorePicturesOpenCloseEventsProvider _storePicturesOpenCloseEventsProvider;

    public PicturesVisualModel(IStorePicturesOpenCloseEventsProvider storePicturesOpenCloseEventsProvider)
    {
        _storePicturesOpenCloseEventsProvider = storePicturesOpenCloseEventsProvider;

        _storePicturesOpenCloseEventsProvider.OnOpenPicture += OpenPicture;
        _storePicturesOpenCloseEventsProvider.OnClosePicture += ClosePicture;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storePicturesOpenCloseEventsProvider.OnOpenPicture -= OpenPicture;
        _storePicturesOpenCloseEventsProvider.OnClosePicture -= ClosePicture;
    }

    private void OpenPicture(int index)
    {
        OnOpenPicture?.Invoke(index);
    }

    private void ClosePicture(int index)
    {
        OnClosePicture?.Invoke(index);
    }



    #region Output

    public event Action<int> OnOpenPicture;
    public event Action<int> OnClosePicture;

    #endregion
}
