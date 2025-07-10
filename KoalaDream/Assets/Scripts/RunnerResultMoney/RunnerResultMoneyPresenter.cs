using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerResultMoneyPresenter : IRunnerResultMoneyEventsProvider, IRunnerResultMoneyInfoProvider, IRunnerResultMoneyProvider
{
    private readonly RunnerResultMoneyModel _model;

    public RunnerResultMoneyPresenter(RunnerResultMoneyModel model)
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

    public event Action<int> OnChangeCountMoney
    {
        add => _model.OnChangeCountMoney += value;
        remove => _model.OnChangeCountMoney -= value;
    }

    #endregion

    #region Input

    public void AddMoney(int count)
    {
        _model.AddMoney(count);
    }

    public void Reset()
    {
        _model.Reset();
    }

    public int GetMoney()
    {
        return _model.GetMoney();
    }

    #endregion
}

public interface IRunnerResultMoneyProvider
{
    void AddMoney(int count);
    void Reset();
}

public interface IRunnerResultMoneyInfoProvider
{
    public int GetMoney();
}

public interface IRunnerResultMoneyEventsProvider
{
    public event Action<int> OnChangeCountMoney;
}
