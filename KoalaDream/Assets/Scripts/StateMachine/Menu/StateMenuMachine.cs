using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMenuMachine : IGlobalStateMachineProvider
{
    private Dictionary<Type, IState> states = new Dictionary<Type, IState>();

    private IState _currentState;

    public StateMenuMachine(
        AutoMovePresenter autoMovePresenter,
        ManualMovePresenter manualMovePresenter,
        IPlayerMoveEventsProvider playerMoveEventsProvider,
        IPlayerMoveProvider playerMoveProvider,
        
        GameMarkerNavigationPresenter gameMarkerNavigationPresenter,
        PlayerMarkerNavigationPresenter playerMarkerNavigationPresenter,
        IMoveMarkerProvider moveMarkerProvider,
        
        IStorePicturesSelectEventsProvider storePicturesSelectEventsProvider,
        UIMainMenuRoot sceneRoot,
        
        IBedGameAccessEventsProvider bedGameAccessEventsProvider,
        IPlayerVisibleProvider playerVisibleProvider,
        IPlayerSleepAnimationProvider playerSleepAnimationProvider)
    {
        states[typeof(PlayerManualState_Menu)] = new PlayerManualState_Menu(this, autoMovePresenter, manualMovePresenter, playerMoveProvider, storePicturesSelectEventsProvider, bedGameAccessEventsProvider);
        states[typeof(FromManualToAutoState_Menu)] = new FromManualToAutoState_Menu(this, gameMarkerNavigationPresenter, playerMarkerNavigationPresenter, moveMarkerProvider);
        states[typeof(PlayerAutoState_Menu)] = new PlayerAutoState_Menu(this, autoMovePresenter, playerMoveProvider);
        states[typeof(FromAutoToManualState_Menu)] = new FromAutoToManualState_Menu(this, gameMarkerNavigationPresenter, playerMarkerNavigationPresenter, moveMarkerProvider);

        states[typeof(ShowPictureState_Menu)] = new ShowPictureState_Menu(this, gameMarkerNavigationPresenter, playerMarkerNavigationPresenter, moveMarkerProvider, sceneRoot);
        states[typeof(OpenPictureState_Menu)] = new OpenPictureState_Menu(this, gameMarkerNavigationPresenter, playerMarkerNavigationPresenter, moveMarkerProvider, sceneRoot);

        states[typeof(FromManualToStartWalkToBedState_Menu)] = new FromManualToStartWalkToBedState_Menu(this, gameMarkerNavigationPresenter, playerMarkerNavigationPresenter, moveMarkerProvider);
        states[typeof(WalkToStartBedState_Menu)] = new WalkToStartBedState_Menu(this, autoMovePresenter, playerMoveProvider);
        states[typeof(StartSleepState_Menu)] = new StartSleepState_Menu(this, playerVisibleProvider, playerSleepAnimationProvider);
    }

    public void Initialize()
    {
        SetState(GetState<PlayerManualState_Menu>());
    }

    public void Dispose()
    {

    }

    public IState GetState<T>() where T : IState
    {
        return states[typeof(T)];
    }

    public void SetState(IState state)
    {
        _currentState?.ExitState();

        _currentState = state;
        _currentState.EnterState();
    }
}
