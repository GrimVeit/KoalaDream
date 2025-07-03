using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePreviewModel
{
    private readonly IStorePicturesSelectEventsProvider _storePicturesSelectEventsProvider;
    private readonly IStorePicturesOpenProvider _storePicturesOpenProvider;

    public PicturePreviewModel(IStorePicturesSelectEventsProvider storePicturesSelectEventsProvider, IStorePicturesOpenProvider storePicturesOpenProvider)
    {
        _storePicturesSelectEventsProvider = storePicturesSelectEventsProvider;
        _storePicturesOpenProvider = storePicturesOpenProvider;

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
        _storePicturesOpenProvider.OpenPicture(picture.Id);
    }
}
