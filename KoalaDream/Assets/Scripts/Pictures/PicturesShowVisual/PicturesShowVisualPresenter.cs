using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturesShowVisualPresenter
{
    private readonly PicturesShowVisualModel _model;
    private readonly PicturesShowVisualView _view;

    public PicturesShowVisualPresenter(PicturesShowVisualModel model, PicturesShowVisualView view)
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
        _model.OnShowPicture += _view.ShowPicture;
    }

    private void DeactivateEvents()
    {
        _model.OnShowPicture -= _view.ShowPicture;
    }
}
