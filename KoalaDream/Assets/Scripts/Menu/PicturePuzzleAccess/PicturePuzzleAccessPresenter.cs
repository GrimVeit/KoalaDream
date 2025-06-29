using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePuzzleAccessPresenter
{
    private readonly PicturePuzzleAccessModel _model;
    private readonly PicturePuzzleAccessView _view;

    public PicturePuzzleAccessPresenter(PicturePuzzleAccessModel model, PicturePuzzleAccessView view)
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
        _view.OnPlayPuzzle += _model.ActivatePuzzle;

        _model.OnOpenAccess += _view.Activate;
        _model.OnCloseAccess += _view.Deactivate;
    }

    private void DeactivateEvents()
    {
        _view.OnPlayPuzzle -= _model.ActivatePuzzle;

        _model.OnOpenAccess -= _view.Activate;
        _model.OnCloseAccess -= _view.Deactivate;
    }

    #region Output

    public event Action OnActivatePuzzle
    {
        add => _model.OnActivatePuzzle += value;
        remove => _model.OnActivatePuzzle -= value;
    }

    #endregion
}
