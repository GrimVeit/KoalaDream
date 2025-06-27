using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPictureState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly GameMarkerNavigationPresenter _markerNavigationPresenter;
    private readonly PlayerMarkerNavigationPresenter _playerMarkerNavigationPresenter;
    private readonly IMoveMarkerProvider _moveMarkerProvider;
    private readonly UIMainMenuRoot _sceneRoot;

    public OpenPictureState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, GameMarkerNavigationPresenter markerNavigationPresenter, PlayerMarkerNavigationPresenter playerMarkerNavigationPresenter, IMoveMarkerProvider moveMarkerProvider, UIMainMenuRoot sceneRoot)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _markerNavigationPresenter = markerNavigationPresenter;
        _playerMarkerNavigationPresenter = playerMarkerNavigationPresenter;
        _moveMarkerProvider = moveMarkerProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToExit_OpenPicture += ChangeStateToManual;

        _markerNavigationPresenter.AllDeactivates();
        _playerMarkerNavigationPresenter.AllDeactivate();
        _moveMarkerProvider.Deactivate();

        _sceneRoot.OpenPicturePanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToExit_OpenPicture -= ChangeStateToManual;

        _markerNavigationPresenter.Activate();
        _playerMarkerNavigationPresenter.AllDeactivatesExcept();
        _moveMarkerProvider.Activate();

        _sceneRoot.ClosePicturePanel();
    }

    private void ChangeStateToManual()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<PlayerManualState_Menu>());
    }
}
