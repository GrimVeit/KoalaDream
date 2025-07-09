using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinExitState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private readonly IPlayerRunnerMoveAutoProvider _playerRunnerMoveAutoProvider;

    private IEnumerator timer;

    public WinExitState_Runner(IGlobalStateMachineProvider machineProvider, IPlayerRunnerMoveAutoProvider playerRunnerMoveAutoProvider)
    {
        _machineProvider = machineProvider;
        _playerRunnerMoveAutoProvider = playerRunnerMoveAutoProvider;
    }

    public void EnterState()
    {
        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(0.3f);
        Coroutines.Start(timer);

        _playerRunnerMoveAutoProvider.MoveToWinExitPosition();
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
