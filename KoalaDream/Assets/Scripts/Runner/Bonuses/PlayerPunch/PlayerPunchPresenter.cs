using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchPresenter
{
    private readonly PlayerPunchModel _model;

    public PlayerPunchPresenter(PlayerPunchModel model)
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
