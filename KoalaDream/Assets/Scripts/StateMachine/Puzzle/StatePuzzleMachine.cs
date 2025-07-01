using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePuzzleMachine : IGlobalStateMachineProvider
{
    private Dictionary<Type, IState> states = new Dictionary<Type, IState>();

    private IState _currentState;

    public StatePuzzleMachine(
        UIGameSceneRoot_Puzzle sceneRoot,
        
        IStorePicturesOpenProvider storePicturesOpenProvider,
        IPuzzleFrameEventsProvider puzzleFrameEventsProvider,
        IPuzzleFrameProvider puzzleFrameProvider)
    {
        states[typeof(MainState_Puzzle)] = new MainState_Puzzle(this, sceneRoot, storePicturesOpenProvider, puzzleFrameEventsProvider);
        states[typeof(HideScrollState_Puzzle)] = new HideScrollState_Puzzle(this, sceneRoot);
        states[typeof(PuzzleScaleState_Puzzle)] = new PuzzleScaleState_Puzzle(this, puzzleFrameProvider);
        states[typeof(ShowFullImageState_Puzzle)] = new ShowFullImageState_Puzzle(this, sceneRoot);
        states[typeof(DarkenFullImageState_Puzzle)] = new DarkenFullImageState_Puzzle(this, sceneRoot);
        states[typeof(ShowGreatTextState_Puzzle)] = new ShowGreatTextState_Puzzle(this, sceneRoot);
        states[typeof(ShowExitState_Puzzle)] = new ShowExitState_Puzzle(this, sceneRoot);
    }

    public void Initialize()
    {
        SetState(GetState<MainState_Puzzle>());
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
