using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSleepState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly IPlayerVisibleProvider _playerVisibleProvider;
    private readonly IPlayerSleepAnimationProvider _sleepAnimationProvider;

    public StartSleepState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, IPlayerVisibleProvider playerVisibleProvider, IPlayerSleepAnimationProvider sleepAnimationProvider)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _playerVisibleProvider = playerVisibleProvider;
        _sleepAnimationProvider = sleepAnimationProvider;
    }

    public void EnterState()
    {
        _playerVisibleProvider.Hide();
        _sleepAnimationProvider.ActivateAnimation();
    }

    public void ExitState()
    {

    }
}
