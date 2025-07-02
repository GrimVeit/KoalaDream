using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisiblePresenter : IPlayerVisibleProvider
{
    private readonly PlayerVisibleModel _model;
    private readonly PlayerVisibleView _view;

    public PlayerVisiblePresenter(PlayerVisibleModel model, PlayerVisibleView view)
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
        _model.OnHidePlayer += _view.Hide;
        _model.OnShowPlayer += _view.Show;
    }

    private void DeactivateEvents()
    {
        _model.OnHidePlayer -= _view.Hide;
        _model.OnShowPlayer -= _view.Show;
    }

    #region Input

    public void Hide()
    {
        _model.Hide();
    }

    public void Show()
    {
        _model.Show();
    }

    #endregion
}

public interface IPlayerVisibleProvider
{
    void Show();
    void Hide();
}
