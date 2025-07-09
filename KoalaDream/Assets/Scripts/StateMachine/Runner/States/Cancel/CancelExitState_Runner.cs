using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelExitState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private readonly IPlayerRunnerMoveAutoProvider _playerRunnerMoveAutoProvider;
    private readonly IPlayerRunnerAnimationProvider _playerRunnerAnimationProvider;
    private readonly IRunnerExitProvider _runnerExitProvider;

    private IEnumerator timer;

    public CancelExitState_Runner(IGlobalStateMachineProvider machineProvider, IPlayerRunnerMoveAutoProvider playerRunnerMoveAutoProvider, IPlayerRunnerAnimationProvider playerRunnerAnimationProvider, IRunnerExitProvider runnerExitProvider)
    {
        _machineProvider = machineProvider;
        _playerRunnerMoveAutoProvider = playerRunnerMoveAutoProvider;
        _playerRunnerAnimationProvider = playerRunnerAnimationProvider;
        _runnerExitProvider = runnerExitProvider;
    }

    public void EnterState()
    {
        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(1f);
        Coroutines.Start(timer);

        _playerRunnerMoveAutoProvider.MoveToLoseExitPosition();
        _playerRunnerAnimationProvider.AnimationDown();
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
