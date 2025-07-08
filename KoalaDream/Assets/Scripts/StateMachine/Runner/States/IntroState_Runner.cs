using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private readonly IPlayerRunnerActivatorEventsProvider _playerRunnerActivatorEventsProvider;
    private readonly IPlayerRunnerActivatorProvider _playerRunnerActivatorProvider;

    private readonly IBackgroundRandomProvider _backgroundRandomProvider;
    private readonly IBackgroundScrollProvider _backgroundScrollProvider;



    public IntroState_Runner(IGlobalStateMachineProvider globalStateMachineProvider, IPlayerRunnerActivatorEventsProvider playerRunnerActivatorEventsProvider, IPlayerRunnerActivatorProvider playerRunnerActivatorProvider, IBackgroundRandomProvider backgroundRandomProvider, IBackgroundScrollProvider backgroundScrollProvider)
    {
        _machineProvider = globalStateMachineProvider;
        _playerRunnerActivatorEventsProvider = playerRunnerActivatorEventsProvider;
        _playerRunnerActivatorProvider = playerRunnerActivatorProvider;
        _backgroundRandomProvider = backgroundRandomProvider;
        _backgroundScrollProvider = backgroundScrollProvider;
    }

    public void EnterState()
    {
        _playerRunnerActivatorEventsProvider.OnActivate += ChangeStateToMain;

        _backgroundRandomProvider.Random();
        _backgroundScrollProvider.DeactivateScroll();
        _playerRunnerActivatorProvider.Activate();
    }

    public void ExitState()
    {
        _playerRunnerActivatorEventsProvider.OnActivate -= ChangeStateToMain;
    }

    private void ChangeStateToMain()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Runner>());
    }
}
