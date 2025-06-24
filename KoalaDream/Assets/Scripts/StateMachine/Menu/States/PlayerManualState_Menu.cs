using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManualState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;
    
    private readonly AutoMovePresenter _autoMovePresenter;
    private readonly ManualMovePresenter _manualMovePresenter;
    private readonly IPlayerMoveProvider _moveProvider;

    public PlayerManualState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, AutoMovePresenter autoMovePresenter, ManualMovePresenter manualMovePresenter, IPlayerMoveProvider moveProvider)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _autoMovePresenter = autoMovePresenter;
        _manualMovePresenter = manualMovePresenter;
        _moveProvider = moveProvider;
    }

    public void EnterState()
    {
        _autoMovePresenter.OnStartMove += ChangeStateToAuto;

        _manualMovePresenter.OnMove += _moveProvider.Move;
    }

    public void ExitState()
    {
        _autoMovePresenter.OnStartMove -= ChangeStateToAuto;

        _manualMovePresenter.OnMove -= _moveProvider.Move;
    }

    private void ChangeStateToAuto()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<FromManualToAutoState_Menu>());
    }
}
