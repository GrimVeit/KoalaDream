using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromManualToAutoState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private GameMarkerNavigationPresenter _markerNavigationPresenter;
    private PlayerMarkerNavigationPresenter _playerMarkerNavigationPresenter;

    public FromManualToAutoState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, GameMarkerNavigationPresenter markerNavigationPresenter, PlayerMarkerNavigationPresenter playerMarkerNavigationPresenter)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _markerNavigationPresenter = markerNavigationPresenter;
        _playerMarkerNavigationPresenter = playerMarkerNavigationPresenter;
    }

    public void EnterState()
    {
        _markerNavigationPresenter.AllDeactivates();
        _playerMarkerNavigationPresenter.AllDeactivate();

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
