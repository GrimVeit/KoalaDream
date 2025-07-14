using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleSoundPresenter
{
    private readonly PlayerObstacleSoundModel _model;

    public PlayerObstacleSoundPresenter(PlayerObstacleSoundModel model)
    {
        _model = model;
    }

    public void Initialize()
    {
        _model.Initialize();
    }

    public void Dispose()
    {
        _model?.Dispose();
    }
}
