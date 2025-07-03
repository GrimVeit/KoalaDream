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
        _view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _model.Dispose();
        _view.Dispose();
    }

    private void ActivateEvents()
    {
        _view.OnSelectPicture += _model.SelectPicture;

        _model.OnOpenPicture += _view.Open;
        _model.OnClosePicture += _view.Close;
        _model.OnPreviewPicture += _view.Preview;
    }

    private void DeactivateEvents()
    {
        _view.OnSelectPicture -= _model.SelectPicture;

        _model.OnOpenPicture -= _view.Open;
        _model.OnClosePicture -= _view.Close;
        _model.OnPreviewPicture -= _view.Preview;
    }
}
