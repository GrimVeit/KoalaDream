using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameSessionState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly GameMarkerNavigationPresenter _markerNavigationPresenter;
    private readonly PlayerMarkerNavigationPresenter _playerMarkerNavigationPresenter;
    private readonly IMoveMarkerProvider _moveMarkerProvider;

    private readonly IGameSessionInfoProvider _gameSessionInfoProvider;

    public CheckGameSessionState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, GameMarkerNavigationPresenter markerNavigationPresenter, PlayerMarkerNavigationPresenter playerMarkerNavigationPresenter, IMoveMarkerProvider moveMarkerProvider, IGameSessionInfoProvider gameSessionInfoProvider)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _markerNavigationPresenter = markerNavigationPresenter;
        _playerMarkerNavigationPresenter = playerMarkerNavigationPresenter;
        _moveMarkerProvider = moveMarkerProvider;
        _gameSessionInfoProvider = gameSessionInfoProvider;
    }

    public void EnterState()
    {
        Debug.Log($"<color=red>CHECK GAME SESSION</color>");

        _markerNavigationPresenter.AllDeactivates();
        _playerMarkerNavigationPresenter.AllDeactivate();
        _moveMarkerProvider.Deactivate();

        switch (_gameSessionInfoProvider.GetGameState())
        {
            case 1:
                ChangeStateToAfterPuzzle();
                break;
            case 2:
                ChangeStateToAfterSleep();
                break;
            default:
                ChangeStateToDefault();
                break;
        }
    }

    public void ExitState()
    {

    }

    private void ChangeStateToAfterPuzzle()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<AfterPuzzleState_Menu>());
    }

    private void ChangeStateToAfterSleep()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<AfterSleepState_Menu>());
    }

    private void ChangeStateToDefault()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<FromAutoToManualState_Menu>());
    }
}
