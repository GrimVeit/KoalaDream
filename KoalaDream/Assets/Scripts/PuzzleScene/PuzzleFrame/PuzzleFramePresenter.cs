using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFramePresenter : IPuzzleFrameEventsProvider, IPuzzleFrameProvider
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
        _view.Dispose();
    }

    private void ActivateEvents()
    {
        _view.OnCompletePuzzle += _model.CompletePuzzle;

        _model.OnShowScale += _view.ShowScale;
        _model.OnSelectFrame += _view.SelectFrame;
    }

    private void DeactivateEvents()
    {
        _view.OnCompletePuzzle -= _model.CompletePuzzle;

        _model.OnShowScale -= _view.ShowScale;
        _model.OnSelectFrame -= _view.SelectFrame;
    }

    #region Output

    public event Action<int> OnCompletePuzzle
    {
        add => _model.OnCompletePuzzle += value;
        remove => _model.OnCompletePuzzle -= value;
    }

    #endregion

    #region Input

    public void ShowScale()
    {
        _model.ShowScale();
    }

    #endregion
}

public interface IPuzzleFrameEventsProvider
{
    public event Action<int> OnCompletePuzzle;
}

public interface IPuzzleFrameProvider
{
    public void ShowScale();
}
