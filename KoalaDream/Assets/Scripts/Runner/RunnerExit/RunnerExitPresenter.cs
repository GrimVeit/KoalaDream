using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerExitPresenter : IRunnerExitProvider
{
    private readonly RunnerExitModel _model;

    public RunnerExitPresenter(RunnerExitModel model)
    {
        _model = model;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    #region Output

    public event Action OnExit
    {
        add => _model.OnExit += value;
        remove => _model.OnExit -= value;
    }

    #endregion

    #region Input

    public void Exit()
    {
        _model.Exit();
    }

    #endregion
}

public interface IRunnerExitProvider
{
    void Exit();
}
