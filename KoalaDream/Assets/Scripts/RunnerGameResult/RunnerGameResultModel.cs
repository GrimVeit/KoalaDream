using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerGameResultModel
{
    private readonly string KEY;

    private int _gameGlobalState;

    public RunnerGameResultModel(string kEY)
    {
        KEY = kEY;
    }

    public void Initialize()
    {
        _gameGlobalState = PlayerPrefs.GetInt(KEY, (int)RunnerResult.None);
        OnSetRunnerResult?.Invoke(GetRunnerResult());
    }

    public void Dispose()
    {
        PlayerPrefs.SetInt(KEY, _gameGlobalState);
    }

    public void SetResult(RunnerResult runner)
    {
        _gameGlobalState = (int)runner;
        OnSetRunnerResult?.Invoke(GetRunnerResult());
    }

    public void Reset()
    {
        _gameGlobalState = (int)RunnerResult.None;
        OnSetRunnerResult?.Invoke(GetRunnerResult());

        PlayerPrefs.DeleteKey(KEY);
    }

    public RunnerResult GetRunnerResult()
    {
        return (RunnerResult)_gameGlobalState;
    }


    #region Output

    public event Action<RunnerResult> OnSetRunnerResult;

    #endregion
}

public enum RunnerResult
{
    None = 0, CancelNoMoney = 1, CancelWithMoney = 2, LoseNoMoney = 3, LoseWithMoney = 4, Win = 5 
}
