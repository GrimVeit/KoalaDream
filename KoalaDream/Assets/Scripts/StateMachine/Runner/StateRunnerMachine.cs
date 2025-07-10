using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRunnerMachine : IGlobalStateMachineProvider
{
    private readonly Dictionary<Type, IState> states = new();

    private IState _currentState;

    public StateRunnerMachine(
        UIGameSceneRoot_Runner sceneRoot,
        
        IBackgroundRandomProvider backgroundRandomProvider,
        IBackgroundScrollProvider backgroundScrollProvider,
        
        IObstacleSpawnerProvider obstacleSpawnerProvider,
        
        ILeafEffectProvider leafEffectProvider,
        IPlayerAddMoneyEventsProvider playerAddMoneyEventsProvider,
        IPlayerRunnerMoveFreezeProvider playerRunnerMoveFreezeProvider,
        IPlayerRunnerMoveAutoEventsProvider playerRunnerMoveAutoEventsProvider,
        IPlayerRunnerMoveAutoProvider playerRunnerMoveAutoProvider,
        IPlayerRunnerDeadZoneEventsProvider playerRunnerDeadZoneEventsProvider,
        IPlayerRunnerAnimationProvider playerRunnerAnimationProvider,
        IRunnerExitProvider runnerExitProvider,
        IRunnerGameResultProvider runnerGameResultProvider,
        IRunnerResultMoneyInfoProvider runnerResultMoneyInfoProvider)
    {
        states[typeof(IntroState_Runner)] = new IntroState_Runner(this, backgroundRandomProvider, backgroundScrollProvider, playerRunnerMoveFreezeProvider, playerRunnerMoveAutoProvider, playerRunnerMoveAutoEventsProvider);
        states[typeof(MainState_Runner)] = new MainState_Runner(this, sceneRoot, backgroundScrollProvider, obstacleSpawnerProvider, leafEffectProvider, playerAddMoneyEventsProvider, playerRunnerDeadZoneEventsProvider);

        states[typeof(WaitShowWinState_Runner)] = new WaitShowWinState_Runner(this, sceneRoot, backgroundScrollProvider, obstacleSpawnerProvider, leafEffectProvider, playerRunnerMoveFreezeProvider, playerRunnerMoveAutoProvider, playerRunnerMoveAutoEventsProvider);
        states[typeof(ShowWinState_Runner)] = new ShowWinState_Runner(this, sceneRoot);
        states[typeof(WinExitState_Runner)] = new WinExitState_Runner(this, playerRunnerMoveAutoProvider, runnerExitProvider, runnerGameResultProvider);

        states[typeof(ShowLoseState_Runner)] = new ShowLoseState_Runner(this, sceneRoot, backgroundScrollProvider, obstacleSpawnerProvider, leafEffectProvider, playerRunnerMoveFreezeProvider);
        states[typeof(LoseExitState_Runner)] = new LoseExitState_Runner(this, playerRunnerMoveAutoProvider, playerRunnerAnimationProvider, runnerExitProvider, runnerGameResultProvider, runnerResultMoneyInfoProvider);

        states[typeof(ShowCancelState_Runner)] = new ShowCancelState_Runner(this, sceneRoot, backgroundScrollProvider, obstacleSpawnerProvider, leafEffectProvider, playerRunnerMoveFreezeProvider);
        states[typeof(CancelExitState_Runner)] = new CancelExitState_Runner(this, playerRunnerMoveAutoProvider, playerRunnerAnimationProvider, runnerExitProvider, runnerGameResultProvider, runnerResultMoneyInfoProvider);
    }

    public void Initialize()
    {
        SetState(GetState<IntroState_Runner>());
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
