using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerResultMoneyVisualModel
{
    private readonly IRunnerResultMoneyEventsProvider _runnerResultMoneyEventsProvider;

    public RunnerResultMoneyVisualModel(IRunnerResultMoneyEventsProvider runnerResultMoneyEventsProvider)
    {
        _runnerResultMoneyEventsProvider = runnerResultMoneyEventsProvider;

        _runnerResultMoneyEventsProvider.OnChangeCountMoney += SetMoney;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _runnerResultMoneyEventsProvider.OnChangeCountMoney -= SetMoney;
    }

    private void SetMoney(int money)
    {
        OnSetMoney?.Invoke(money);
    }

    public event Action<int> OnSetMoney;
}
