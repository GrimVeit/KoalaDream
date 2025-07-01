using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePuzzleMachine : IGlobalStateMachineProvider
{
    private Dictionary<Type, IState> states = new Dictionary<Type, IState>();

    private IState _currentState;

    public StatePuzzleMachine()
    {
        states[typeof(MainState_Puzzle)] = new MainState_Puzzle();
        states[typeof(HideScrollState_Puzzle)] = new HideScrollState_Puzzle();
        states[typeof(PuzzleScaleState_Puzzle)] = new PuzzleScaleState_Puzzle();
        states[typeof(ShowFullImageState_Puzzle)] = new ShowFullImageState_Puzzle();
        states[typeof(DarkenFullImageState_Puzzle)] = new DarkenFullImageState_Puzzle();
        states[typeof(ShowGreatTextState_Puzzle)] = new ShowGreatTextState_Puzzle();
        states[typeof(ShowExitState_Puzzle)] = new ShowExitState_Puzzle();
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
