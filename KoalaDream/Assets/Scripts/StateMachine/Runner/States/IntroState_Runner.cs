using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    //private readonly IPlayerRunnerActivatorEventsProvider _playerRunnerActivatorEventsProvider;
    //private readonly IPlayerRunnerActivatorProvider _playerRunnerActivatorProvider;

    private readonly IBackgroundRandomProvider _backgroundRandomProvider;
    private readonly IBackgroundScrollProvider _backgroundScrollProvider;

    private readonly IPlayerRunnerMoveFreezeProvider _playerRunnerMoveFreezeProvider;
    private readonly IPlayerRunnerMoveAutoProvider _playerRunnerMoveAutoProvider;
    private readonly IPlayerRunnerMoveAutoEventsProvider _playerRunnerMoveAutoEventsProvider;



    public IntroState_Runner(IGlobalStateMachineProvider globalStateMachineProvider, IBackgroundRandomProvider backgroundRandomProvider, IBackgroundScrollProvider backgroundScrollProvider, IPlayerRunnerMoveFreezeProvider playerRunnerMoveFreezeProvider, IPlayerRunnerMoveAutoProvider playerRunnerMoveAutoProvider, IPlayerRunnerMoveAutoEventsProvider playerRunnerMoveAutoEventsProvider)
    {
        _machineProvider = globalStateMachineProvider;
        _backgroundRandomProvider = backgroundRandomProvider;
        _backgroundScrollProvider = backgroundScrollProvider;
        _playerRunnerMoveFreezeProvider = playerRunnerMoveFreezeProvider;
        _playerRunnerMoveAutoProvider = playerRunnerMoveAutoProvider;
        _playerRunnerMoveAutoEventsProvider = playerRunnerMoveAutoEventsProvider;
    }

    public void EnterState()
    {
        _playerRunnerMoveAutoEventsProvider.OnMovePlayerToStartGamePosition += ChangeStateToMain;

        _playerRunnerMoveFreezeProvider.Freeze();
        _playerRunnerMoveAutoProvider.MoveToStartGamePosition();

        _backgroundRandomProvider.Random();
        _backgroundScrollProvider.DeactivateScroll();
    }

    public void ExitState()
    {
        _playerRunnerMoveAutoEventsProvider.OnMovePlayerToStartGamePosition -= ChangeStateToMain;

        _playerRunnerMoveFreezeProvider.Unfreeze();
    }

    private void ChangeStateToMain()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Runner>());
    }
}
