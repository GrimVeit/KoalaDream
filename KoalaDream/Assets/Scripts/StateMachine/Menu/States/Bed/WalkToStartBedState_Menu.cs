using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToStartBedState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly AutoMovePresenter _autoMovePresenter;
    private readonly IPlayerMoveProvider _moveProvider;

    public WalkToStartBedState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, AutoMovePresenter autoMovePresenter, IPlayerMoveProvider moveProvider)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _autoMovePresenter = autoMovePresenter;
        _moveProvider = moveProvider;
    }

    public void EnterState()
    {
        _autoMovePresenter.OnEndMove += ChangeStateToStartSleep;

        _autoMovePresenter.Move(1);
    }

    public void ExitState()
    {
        _autoMovePresenter.OnEndMove -= ChangeStateToStartSleep;
    }

    private void ChangeStateToStartSleep()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<StartSleepState_Menu>());
    }
}
