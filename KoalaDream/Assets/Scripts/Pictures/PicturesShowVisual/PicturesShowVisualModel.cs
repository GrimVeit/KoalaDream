using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturesShowVisualModel
{
    private readonly IStorePicturesSelectEventsProvider _storePicturesSelectEventsProvider;

    public PicturesShowVisualModel(IStorePicturesSelectEventsProvider storePicturesSelectEventsProvider)
    {
        _storePicturesSelectEventsProvider = storePicturesSelectEventsProvider;

        _storePicturesSelectEventsProvider.OnSelectOpenPicture_Value += ShowPicture;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storePicturesSelectEventsProvider.OnSelectOpenPicture_Value -= ShowPicture;
    }

    private void ShowPicture(int index)
    {
        OnShowPicture?.Invoke(index);
    }

    #region Output

    public event Action<int> OnShowPicture;

    #endregion
}
