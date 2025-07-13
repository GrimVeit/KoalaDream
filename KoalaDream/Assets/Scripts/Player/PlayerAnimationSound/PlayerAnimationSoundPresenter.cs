using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSoundPresenter
{
    private readonly PlayerAnimationSoundModel _model;
    private readonly PlayerAnimationSoundView _view;

    public PlayerAnimationSoundPresenter(PlayerAnimationSoundModel model, PlayerAnimationSoundView view)
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
        _view.OnActivateSound += _model.ActivateSound;
    }

    private void DeactivateEvents()
    {
        _view.OnActivateSound -= _model.ActivateSound;
    }
}
