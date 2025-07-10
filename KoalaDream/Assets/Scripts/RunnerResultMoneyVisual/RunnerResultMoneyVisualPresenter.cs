using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerResultMoneyVisualPresenter
{
    private readonly RunnerResultMoneyVisualModel _model;
    private readonly RunnerResultMoneyVisualView _view;

    public RunnerResultMoneyVisualPresenter(RunnerResultMoneyVisualModel model, RunnerResultMoneyVisualView view)
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
        _model.OnSetMoney += _view.SetMoney;
    }

    private void DeactivateEvents()
    {
        _model.OnSetMoney -= _view.SetMoney;
    }
}
