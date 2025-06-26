using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromManualToAutoState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly GameMarkerNavigationPresenter _markerNavigationPresenter;
    private readonly PlayerMarkerNavigationPresenter _playerMarkerNavigationPresenter;
    private readonly IMoveMarkerProvider _moveMarkerProvider;

    public FromManualToAutoState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, GameMarkerNavigationPresenter markerNavigationPresenter, PlayerMarkerNavigationPresenter playerMarkerNavigationPresenter, IMoveMarkerProvider moveMarkerProvider)
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

        ChangeStateToAuto();
    }

    public void ExitState()
    {

    }

    private void ChangeStateToAuto()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<PlayerAutoState_Menu>());
    }
}
