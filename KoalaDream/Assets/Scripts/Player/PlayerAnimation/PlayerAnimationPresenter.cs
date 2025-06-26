using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationPresenter
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
    }

    private void DeactivateEvents()
    {
        _model.OnChangeState -= _view.SetState;
    }
}
