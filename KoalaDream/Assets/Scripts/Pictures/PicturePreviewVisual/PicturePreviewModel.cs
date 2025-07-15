using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePreviewModel
{
    private readonly IStorePicturesSelectEventsProvider _storePicturesSelectEventsProvider;
    private readonly IStorePicturesOpenProvider _storePicturesOpenProvider;

    private readonly ISoundProvider _soundProvider;

    public PicturePreviewModel(IStorePicturesSelectEventsProvider storePicturesSelectEventsProvider, IStorePicturesOpenProvider storePicturesOpenProvider, ISoundProvider soundProvider)
    {
        _storePicturesSelectEventsProvider = storePicturesSelectEventsProvider;
        _storePicturesOpenProvider = storePicturesOpenProvider;
        _soundProvider = soundProvider;

        _storePicturesSelectEventsProvider.OnSelectPreviewPicture_Value += PreviewPicture;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storePicturesSelectEventsProvider.OnSelectPreviewPicture_Value -= PreviewPicture;
    }

    private void PreviewPicture(Picture picture)
    {
        _soundProvider.PlayOneShot("Click_OpenNewPicture");

        _storePicturesOpenProvider.OpenPicture(picture.Id);
    }
}
