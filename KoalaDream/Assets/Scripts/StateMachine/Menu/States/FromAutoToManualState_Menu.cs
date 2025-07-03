using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromAutoToManualState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly GameMarkerNavigationPresenter _markerNavigationPresenter;
    private readonly PlayerMarkerNavigationPresenter _playerMarkerNavigationPresenter;
    private readonly IMoveMarkerProvider _moveMarkerProvider;

    public FromAutoToManualState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, GameMarkerNavigationPresenter markerNavigationPresenter, PlayerMarkerNavigationPresenter playerMarkerNavigationPresenter, IMoveMarkerProvider moveMarkerProvider)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _markerNavigationPresenter = markerNavigationPresenter;
        _playerMarkerNavigationPresenter = playerMarkerNavigationPresenter;
        _moveMarkerProvider = moveMarkerProvider;
    }

    public void EnterState()
    {
        Debug.Log($"<color=red>FROM AUTO TO MANUAL</color>");

        _markerNavigationPresenter.Activate();
        _playerMarkerNavigationPresenter.AllDeactivatesExcept();
        _moveMarkerProvider.Activate();

        ChangeStateToManual();
    }

    public void ExitState()
    {

    }

    private void ChangeStateToManual()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<PlayerManualState_Menu>());
    }
}
