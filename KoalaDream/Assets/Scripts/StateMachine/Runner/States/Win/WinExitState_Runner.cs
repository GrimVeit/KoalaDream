using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinExitState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private readonly IPlayerRunnerMoveAutoProvider _playerRunnerMoveAutoProvider;
    private readonly IRunnerExitProvider _runnerExitProvider;
    private readonly IRunnerGameResultProvider _gameResultProvider;

    private IEnumerator timer;

    public WinExitState_Runner(IGlobalStateMachineProvider machineProvider, IPlayerRunnerMoveAutoProvider playerRunnerMoveAutoProvider, IRunnerExitProvider runnerExitProvider, IRunnerGameResultProvider gameResultProvider)
    {
        _machineProvider = machineProvider;
        _playerRunnerMoveAutoProvider = playerRunnerMoveAutoProvider;
        _runnerExitProvider = runnerExitProvider;
        _gameResultProvider = gameResultProvider;
    }

    public void EnterState()
    {
        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(1f);
        Coroutines.Start(timer);

        _playerRunnerMoveAutoProvider.MoveToWinExitPosition();

        _gameResultProvider.SetResult(RunnerResult.Win);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        _runnerExitProvider.Exit();
    }
}
