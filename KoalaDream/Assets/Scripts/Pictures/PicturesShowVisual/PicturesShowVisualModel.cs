using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturesShowVisualModel
{
    private readonly IStorePicturesSelectEventsProvider _storePicturesSelectEventsProvider;

    private readonly ISoundProvider _soundProvider;

    public PicturesShowVisualModel(IStorePicturesSelectEventsProvider storePicturesSelectEventsProvider, ISoundProvider soundProvider)
    {
        _storePicturesSelectEventsProvider = storePicturesSelectEventsProvider;
        _soundProvider = soundProvider;

        _storePicturesSelectEventsProvider.OnSelectOpenPicture_Value += ShowPicture;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storePicturesSelectEventsProvider.OnSelectOpenPicture_Value -= ShowPicture;
    }

    private void ShowPicture(Picture picture)
    {
        _soundProvider.PlayOneShot("Click_OpenPicture");

        OnShowPicture?.Invoke(picture);
    }

    #region Output

    public event Action<Picture> OnShowPicture;

    #endregion
}
