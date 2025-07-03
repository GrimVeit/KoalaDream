using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterPuzzleState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly IPlayerMoveProvider _moveProvider;
    private readonly IPlayerAnimationProvider _animationProvider;

    public AfterPuzzleState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, IPlayerMoveProvider moveProvider, IPlayerAnimationProvider animationProvider)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _moveProvider = moveProvider;
        _animationProvider = animationProvider;
    }

    public void EnterState()
    {
        Debug.Log($"<color=red>AFTER PUZZLE</color>");

        _moveProvider.Teleport(0);
        _animationProvider.Left();

        ChangeStateToManual();
    }

    public void ExitState()
    {

    }

    private void ChangeStateToManual()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<FromAutoToManualState_Menu>());
    }
}
