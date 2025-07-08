using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRunnerMachine : IGlobalStateMachineProvider
{
    private readonly Dictionary<Type, IState> states = new();

    private IState _currentState;

    public StateRunnerMachine(
        IPlayerRunnerActivatorEventsProvider playerRunnerActivatorEventsProvider,
        IPlayerRunnerActivatorProvider playerRunnerActivatorProvider,

        UIGameSceneRoot_Runner sceneRoot,
        
        IBackgroundRandomProvider backgroundRandomProvider,
        IBackgroundScrollProvider backgroundScrollProvider,
        
        IObstacleSpawnerProvider obstacleSpawnerProvider)
    {
        states[typeof(IntroState_Runner)] = new IntroState_Runner(this, playerRunnerActivatorEventsProvider, playerRunnerActivatorProvider, backgroundRandomProvider, backgroundScrollProvider);
        states[typeof(MainState_Runner)] = new MainState_Runner(this, sceneRoot, backgroundScrollProvider, obstacleSpawnerProvider);
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
