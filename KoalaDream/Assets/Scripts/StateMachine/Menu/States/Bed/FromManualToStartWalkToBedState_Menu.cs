using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromManualToStartWalkToBedState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly GameMarkerNavigationPresenter _markerNavigationPresenter;
    private readonly PlayerMarkerNavigationPresenter _playerMarkerNavigationPresenter;
    private readonly IMoveMarkerProvider _moveMarkerProvider;

    public FromManualToStartWalkToBedState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, GameMarkerNavigationPresenter markerNavigationPresenter, PlayerMarkerNavigationPresenter playerMarkerNavigationPresenter, IMoveMarkerProvider moveMarkerProvider)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _markerNavigationPresenter = markerNavigationPresenter;
        _playerMarkerNavigationPresenter = playerMarkerNavigationPresenter;
        _moveMarkerProvider = moveMarkerProvider;
    }

    public void EnterState()
    {
        _markerNavigationPresenter.AllDeactivates();
        _playerMarkerNavigationPresenter.AllDeactivate();
        _moveMarkerProvider.Deactivate();

        ChangeStateToStartWalkToBed();
    }

    public void ExitState()
    {

    }

    private void ChangeStateToStartWalkToBed()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<WalkToStartBedState_Menu>());
    }
}
