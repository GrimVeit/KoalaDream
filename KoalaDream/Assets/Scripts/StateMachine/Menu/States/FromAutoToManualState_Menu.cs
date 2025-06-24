using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromAutoToManualState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private GameMarkerNavigationPresenter _markerNavigationPresenter;
    private PlayerMarkerNavigationPresenter _playerMarkerNavigationPresenter;

    public FromAutoToManualState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, GameMarkerNavigationPresenter markerNavigationPresenter, PlayerMarkerNavigationPresenter playerMarkerNavigationPresenter)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _markerNavigationPresenter = markerNavigationPresenter;
        _playerMarkerNavigationPresenter = playerMarkerNavigationPresenter;
    }

    public void EnterState()
    {
        _markerNavigationPresenter.Activate();
        _playerMarkerNavigationPresenter.AllDeactivatesExcept();

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
