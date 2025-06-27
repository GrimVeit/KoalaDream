using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPictureState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _globalStateMachineProvider;

    private readonly GameMarkerNavigationPresenter _markerNavigationPresenter;
    private readonly PlayerMarkerNavigationPresenter _playerMarkerNavigationPresenter;
    private readonly IMoveMarkerProvider _moveMarkerProvider;
    private readonly UIMainMenuRoot _sceneRoot;

    public ShowPictureState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, GameMarkerNavigationPresenter markerNavigationPresenter, PlayerMarkerNavigationPresenter playerMarkerNavigationPresenter, IMoveMarkerProvider moveMarkerProvider, UIMainMenuRoot sceneRoot)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _markerNavigationPresenter = markerNavigationPresenter;
        _playerMarkerNavigationPresenter = playerMarkerNavigationPresenter;
        _moveMarkerProvider = moveMarkerProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToExit_ShowPicture += ChangeStateToManual;

        _markerNavigationPresenter.AllDeactivates();
        _playerMarkerNavigationPresenter.AllDeactivate();
        _moveMarkerProvider.Deactivate();

        _sceneRoot.OpenShowPicturePanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToExit_ShowPicture -= ChangeStateToManual;

        _markerNavigationPresenter.Activate();
        _playerMarkerNavigationPresenter.AllDeactivatesExcept();
        _moveMarkerProvider.Activate();

        _sceneRoot.CloseShowPicturePanel();
    }

    private void ChangeStateToManual()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<PlayerManualState_Menu>());
    }
}
