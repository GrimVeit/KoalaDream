using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationPresenter : IPlayerAnimationProvider
{
    private readonly PlayerAnimationModel _model;
    private readonly PlayerAnimationView _view;

    public PlayerAnimationPresenter(PlayerAnimationModel model, PlayerAnimationView view)
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
        _model.OnChangeState += _view.SetState;
        _model.OnLeft += _view.RotateLeft;
        _model.OnRight += _view.RotateRight;
    }

    private void DeactivateEvents()
    {
        _model.OnChangeState -= _view.SetState;
        _model.OnLeft -= _view.RotateLeft;
        _model.OnRight -= _view.RotateRight;
    }

    #region Input

    public void Left()
    {
        _model.Left();
    }

    public void Right()
    {
        _model.Right();
    }

    #endregion
}

public interface IPlayerAnimationProvider
{
    void Left();
    void Right();
}
