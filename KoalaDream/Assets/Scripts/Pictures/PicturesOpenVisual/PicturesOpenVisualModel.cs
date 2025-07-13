using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturesOpenVisualModel
{
    private readonly IStorePicturesSelectEventsProvider _storePicturesSelectEventsProvider;

    private readonly ISoundProvider _soundProvider;

    public PicturesOpenVisualModel(IStorePicturesSelectEventsProvider storePicturesSelectEventsProvider, ISoundProvider soundProvider)
    {
        _storePicturesSelectEventsProvider = storePicturesSelectEventsProvider;
        _soundProvider = soundProvider;

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
        _soundProvider.PlayOneShot("Click_ClosePicture");

        OnOpenPicture?.Invoke(picture);
    }

    #region Output

    public event Action<Picture> OnOpenPicture;

    #endregion
}
