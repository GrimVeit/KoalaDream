using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerGameResultPresenter : IRunnerGameResultProvider, IRunnerGameResultInfoProvider, IRunnerGameResultEventsProvider
{
    private readonly RunnerGameResultModel _model;

    public RunnerGameResultPresenter(RunnerGameResultModel model)
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

    public event Action<RunnerResult> OnSetRunnerResult
    {
        add => _model.OnSetRunnerResult += value;
        remove => _model.OnSetRunnerResult -= value;
    }

    public RunnerResult GetRunnerResult()
    {
        return _model.GetRunnerResult();
    }

    #endregion


    #region Input


    public void SetResult(RunnerResult result)
    {
        _model.SetResult(result);
    }

    public void Reset()
    {
        _model.Reset();
    }

    #endregion
}

public interface IRunnerGameResultProvider
{
    public void SetResult(RunnerResult runner);
    public void Reset();
}

public interface IRunnerGameResultEventsProvider
{
    public event Action<RunnerResult> OnSetRunnerResult;
}

public interface IRunnerGameResultInfoProvider
{
    public RunnerResult GetRunnerResult();
}