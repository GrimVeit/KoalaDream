using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddMoneyPresenter : IPlayerAddMoneyEventsProvider
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

    #region Output

    public event Action OnWin
    {
        add => _model.OnWin += value;
        remove => _model.OnWin -= value;
    }

    #endregion
}

public interface IPlayerAddMoneyEventsProvider
{
    public event Action OnWin;
}
