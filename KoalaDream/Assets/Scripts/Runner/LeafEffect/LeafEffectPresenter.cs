using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafEffectPresenter : ILeafEffectProvider
{
    private readonly LeafEffectModel _model;
    private readonly LeafEffectView _view;

    public LeafEffectPresenter(LeafEffectModel model, LeafEffectView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        _model.OnActivateLeaf += _view.ActivateLeaf;
    }

    private void DeactivateEvents()
    {
        _model.OnActivateLeaf -= _view.ActivateLeaf;
    }

    #region Input

    public void ActivateLeafTimer()
    {
        _model.ActivateLeafTimer();
    }

    public void DeactivateLeafTimer()
    {
        _model.DeactivateLeafTimer();
    }

    #endregion
}

public interface ILeafEffectProvider
{
    public void ActivateLeafTimer();
    public void DeactivateLeafTimer();
}
