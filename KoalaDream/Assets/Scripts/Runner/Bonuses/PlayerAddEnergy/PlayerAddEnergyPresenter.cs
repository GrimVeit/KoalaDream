using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddEnergyPresenter
{
    private readonly PlayerAddEnergyModel _model;

    public PlayerAddEnergyPresenter(PlayerAddEnergyModel model)
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
