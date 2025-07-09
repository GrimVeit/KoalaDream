using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseExitState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private readonly IPlayerRunnerMoveAutoProvider _playerRunnerMoveAutoProvider;
    private readonly IPlayerRunnerAnimationProvider _playerRunnerAnimationProvider;

    private IEnumerator timer;

    public LoseExitState_Runner(IGlobalStateMachineProvider machineProvider, IPlayerRunnerMoveAutoProvider playerRunnerMoveAutoProvider, IPlayerRunnerAnimationProvider playerRunnerAnimationProvider)
    {
        _machineProvider = machineProvider;
        _playerRunnerMoveAutoProvider = playerRunnerMoveAutoProvider;
        _playerRunnerAnimationProvider = playerRunnerAnimationProvider;
    }

    public void EnterState()
    {
        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(0.3f);
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

        //ChangeStateToShowWin();
    }
}
