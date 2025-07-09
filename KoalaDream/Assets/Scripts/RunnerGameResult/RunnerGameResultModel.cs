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
    }

    public void Dispose()
    {
        PlayerPrefs.SetInt(KEY, _gameGlobalState);
    }

    public void SetResult(RunnerResult runner)
    {
        _gameGlobalState = (int)runner;
    }

    public void Reset()
    {
        _gameGlobalState = (int)RunnerResult.None;

        PlayerPrefs.DeleteKey(KEY);
    }

    public RunnerResult GetRunnerResult()
    {
        return (RunnerResult)_gameGlobalState;
    }
}

public enum RunnerResult
{
    None = 0, Cancel = 1, Win = 2, Lose = 3
}
