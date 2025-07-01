using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleElementPresenter
{
    private readonly PuzzleElementModel _model;
    private readonly PuzzleElementView _view;

    public PuzzleElementPresenter(PuzzleElementModel pseudoChipModel, PuzzleElementView pseudoChipView)
    {
        _model = pseudoChipModel;
        _view = pseudoChipView;
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
        _view.OnGrabPuzzleElement_Action += _model.GrabPuzzleElement;
        _view.OnStartMove_Action += _model.StartMove;
        _view.OnMove_Action += _model.Move;
        _view.OnEndMove_Action += _model.EndMove;

        _model.OnSelectPuzzles += _view.SetPuzzleElements;

        _model.OnGrabPuzzleElement += _view.GrabPuzzleElement;
        _model.OnUngrabCurrentPuzzleElement += _view.UngrabCurrentPuzzleElement;
        _model.OnStartMove += _view.StartMove;
        _model.OnMove += _view.Move;
        _model.OnEndMove += _view.EndMove;
        _model.OnDestroy += _view.Destroy;
    }

    private void DeactivateEvents()
    {
        _view.OnGrabPuzzleElement_Action -= _model.GrabPuzzleElement;
        _view.OnStartMove_Action -= _model.StartMove;
        _view.OnMove_Action -= _model.Move;
        _view.OnEndMove_Action -= _model.EndMove;

        _model.OnSelectPuzzles -= _view.SetPuzzleElements;

        _model.OnGrabPuzzleElement -= _view.GrabPuzzleElement;
        _model.OnUngrabCurrentPuzzleElement -= _view.UngrabCurrentPuzzleElement;
        _model.OnStartMove -= _view.StartMove;
        _model.OnMove -= _view.Move;
        _model.OnEndMove -= _view.EndMove;
        _model.OnDestroy -= _view.Teleport;
        _model.OnDestroy -= _view.Destroy;
    }
}
