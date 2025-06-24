using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly AutoMovePresenter _autoMovePresenter;
    private readonly IPlayerMoveProvider _moveProvider;

    public PlayerAutoState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, AutoMovePresenter autoMovePresenter, IPlayerMoveProvider moveProvider)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _autoMovePresenter = autoMovePresenter;
        _moveProvider = moveProvider;
    }

    public void EnterState()
    {
        _autoMovePresenter.OnEndMove += ChangeStateToManual;
    }

    public void ExitState()
    {
        _autoMovePresenter.OnEndMove -= ChangeStateToManual;
    }

    private void ChangeStateToManual()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<FromAutoToManualState_Menu>());
    }
}
