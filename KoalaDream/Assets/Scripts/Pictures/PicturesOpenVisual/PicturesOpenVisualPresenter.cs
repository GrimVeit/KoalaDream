using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturesOpenVisualPresenter
{
    private readonly PicturesOpenVisualModel _model;
    private readonly PicturesOpenVisualView _view;

    public PicturesOpenVisualPresenter(PicturesOpenVisualModel model, PicturesOpenVisualView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _model.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _model.Dispose();
    }

    private void ActivateEvents()
    {
        _model.OnOpenPicture += _view.OpenPicture;
    }

    private void DeactivateEvents()
    {
        _model.OnOpenPicture -= _view.OpenPicture;
    }
}
