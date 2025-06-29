using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFramePresenter
{
    private readonly PuzzleFrameModel _model;
    private readonly PuzzleFrameView _view;

    public PuzzleFramePresenter(PuzzleFrameModel model, PuzzleFrameView view)
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
        _model.OnSelectFrame += _view.SelectFrame;
    }

    private void DeactivateEvents()
    {
        _model.OnSelectFrame -= _view.SelectFrame;
    }
}
