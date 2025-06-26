using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturesVisualPresenter
{
    private readonly PicturesVisualModel _model;
    private readonly PicturesVisualView _view;

    public PicturesVisualPresenter(PicturesVisualModel model, PicturesVisualView view)
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
        _model.OnOpenPicture += _view.Open;
        _model.OnClosePicture += _view.Close;
    }

    private void DeactivateEvents()
    {
        _model.OnOpenPicture -= _view.Open;
        _model.OnClosePicture -= _view.Close;
    }
}
