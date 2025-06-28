using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturesOpenVisualModel
{
    private readonly IStorePicturesSelectEventsProvider _storePicturesSelectEventsProvider;

    public PicturesOpenVisualModel(IStorePicturesSelectEventsProvider storePicturesSelectEventsProvider)
    {
        _storePicturesSelectEventsProvider = storePicturesSelectEventsProvider;

        _storePicturesSelectEventsProvider.OnSelectClosePicture_Value += OpenPicture;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storePicturesSelectEventsProvider.OnSelectClosePicture_Value -= OpenPicture;
    }

    private void OpenPicture(Picture picture)
    {
        OnOpenPicture?.Invoke(picture);
    }

    #region Output

    public event Action<Picture> OnOpenPicture;

    #endregion
}
