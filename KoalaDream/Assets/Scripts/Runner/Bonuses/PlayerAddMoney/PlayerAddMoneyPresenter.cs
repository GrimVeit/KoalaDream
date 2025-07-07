using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddMoneyPresenter
{
    private readonly PlayerAddMoneyModel _model;

    public PlayerAddMoneyPresenter(PlayerAddMoneyModel model)
    {
        _model = model;
    }

    public void Initialize()
    {
        _model.Initialize();
    }

    public void Dispose()
    {
        _model.Dispose();
    }
}
