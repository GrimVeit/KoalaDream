using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDemonstrationPresenter
{
    private readonly PuzzleDemonstrationModel _model;
    private readonly PuzzleDemonstrationView _view;

    public PuzzleDemonstrationPresenter(PuzzleDemonstrationModel model, PuzzleDemonstrationView view)
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
        _model.OnSelectPuzzle += _view.SelectPuzzle;
    }

    private void DeactivateEvents()
    {
        _model.OnSelectPuzzle -= _view.SelectPuzzle;
    }
}
