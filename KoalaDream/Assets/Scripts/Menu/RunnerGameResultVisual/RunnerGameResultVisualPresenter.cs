using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerGameResultVisualPresenter
{
    private readonly RunnerGameResultVisualModel _model;
    private readonly RunnerGameResultVisualView _view;

    public RunnerGameResultVisualPresenter(RunnerGameResultVisualModel model, RunnerGameResultVisualView view)
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
        _model.OnSetRunnerResult += _view.SetRunnerResult;
    }

    private void DeactivateEvents()
    {
        _model.OnSetRunnerResult -= _view.SetRunnerResult;
    }
}
