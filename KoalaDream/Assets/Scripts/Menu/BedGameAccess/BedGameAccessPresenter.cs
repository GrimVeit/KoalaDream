using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedGameAccessPresenter : IBedGameAccessEventsProvider
{
    private readonly BedGameAccessModel _model;
    private readonly BedGameAccessView _view;

    public BedGameAccessPresenter(BedGameAccessModel model, BedGameAccessView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _view.Dispose();
    }

    private void ActivateEvents()
    {
        _view.OnActivateGame += _model.ActivateGame;
    }

    private void DeactivateEvents()
    {
        _view.OnActivateGame -= _model.ActivateGame;
    }

    #region Output

    public event Action OnActivateGame
    {
        add => _model.OnActivateGame += value;
        remove => _model.OnActivateGame -= value;
    }

    #endregion
}

public interface IBedGameAccessEventsProvider
{
    public event Action OnActivateGame;
}
