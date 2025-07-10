using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerGameResultVisualModel
{
    private readonly IRunnerGameResultEventsProvider _runnerGameResultEventsProvider;

    public RunnerGameResultVisualModel(IRunnerGameResultEventsProvider runnerGameResultEventsProvider)
    {
        _runnerGameResultEventsProvider = runnerGameResultEventsProvider;

        _runnerGameResultEventsProvider.OnSetRunnerResult += SetRunnerResult;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _runnerGameResultEventsProvider.OnSetRunnerResult -= SetRunnerResult;
    }

    private void SetRunnerResult(RunnerResult runnerResult)
    {
        OnSetRunnerResult?.Invoke(runnerResult);
    }

    #region Output

    public event Action<RunnerResult> OnSetRunnerResult;

    #endregion
}
