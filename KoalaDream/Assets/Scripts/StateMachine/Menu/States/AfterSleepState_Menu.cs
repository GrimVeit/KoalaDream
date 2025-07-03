using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterSleepState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly IPlayerVisibleProvider _playerVisibleProvider;
    private readonly IPlayerMoveProvider _moveProvider;
    private readonly IPlayerAnimationProvider _animationProvider;

    private readonly IPlayerSleepAnimationProvider _sleepAnimationProvider;
    private readonly IPlayerSleepAnimationEventsProvider _sleepAnimationEventsProvider;

    public AfterSleepState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, IPlayerMoveProvider moveProvider, IPlayerAnimationProvider animationProvider, IPlayerVisibleProvider playerVisibleProvider, IPlayerSleepAnimationProvider sleepAnimationProvider, IPlayerSleepAnimationEventsProvider sleepAnimationEventsProvider)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _moveProvider = moveProvider;
        _animationProvider = animationProvider;
        _playerVisibleProvider = playerVisibleProvider;
        _sleepAnimationProvider = sleepAnimationProvider;
        _sleepAnimationEventsProvider = sleepAnimationEventsProvider;
    }

    public void EnterState()
    {
        Debug.Log($"<color=red>AFTER SLEEP 1</color>");

        _sleepAnimationEventsProvider.OnEndDeactivate += ChangeStateToManual;

        _playerVisibleProvider.Hide();
        _moveProvider.Teleport(1);
        _animationProvider.Right();
        _sleepAnimationProvider.DeactivateAnimation();
    }

    public void ExitState()
    {
        _sleepAnimationEventsProvider.OnEndDeactivate -= ChangeStateToManual;
    }

    private void ChangeStateToManual()
    {
        _playerVisibleProvider.Show();

        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<FromAutoToManualState_Menu>());
    }
}
