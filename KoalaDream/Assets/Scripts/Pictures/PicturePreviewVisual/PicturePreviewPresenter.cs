using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePreviewPresenter
{
    private readonly PicturePreviewModel _model;

    public PicturePreviewPresenter(PicturePreviewModel model)
    {
        _model = model;
    }

    public void Initialize()
    {
        _model.Initialize();
    }

    public void Dispose()
    {
        _model.Dispose();
    }
}
