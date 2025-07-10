using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToPictureState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly AutoMovePresenter _autoMovePresenter;

    public WalkToPictureState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, AutoMovePresenter autoMovePresenter)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _autoMovePresenter = autoMovePresenter;
    }

    public void EnterState()
    {
        Debug.Log($"<color=red>WALK TO PICTURES</color>");

        _autoMovePresenter.OnEndMove += ChangeStateToNormal;

        _autoMovePresenter.Move(0);
    }

    public void ExitState()
    {
        _autoMovePresenter.OnEndMove -= ChangeStateToNormal;
    }

    private void ChangeStateToNormal()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<FromAutoToManualState_Menu>());
    }
}
