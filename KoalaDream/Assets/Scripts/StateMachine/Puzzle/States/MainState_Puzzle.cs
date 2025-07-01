using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState_Puzzle : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Puzzle _sceneRoot;

    private readonly IStorePicturesOpenProvider _storePicturesOpenProvider;
    private readonly IPuzzleFrameEventsProvider _puzzleFrameEventsProvider;

    public MainState_Puzzle(IGlobalStateMachineProvider globalStateMachineProvider, UIGameSceneRoot_Puzzle sceneRoot, IStorePicturesOpenProvider storePicturesOpenProvider, IPuzzleFrameEventsProvider puzzleFrameEventsProvider)
    {
        _machineProvider = globalStateMachineProvider;
        _sceneRoot = sceneRoot;
        _storePicturesOpenProvider = storePicturesOpenProvider;
        _puzzleFrameEventsProvider = puzzleFrameEventsProvider;
    }

    public void EnterState()
    {
        _puzzleFrameEventsProvider.OnCompletePuzzle += ChangeStateToHideScroll;

        _sceneRoot.OpenPuzzlesScrollPanel();
    }

    public void ExitState()
    {
        _puzzleFrameEventsProvider.OnCompletePuzzle -= ChangeStateToHideScroll;
    }

    private void ChangeStateToHideScroll(int id)
    {
        //_storePicturesOpenProvider.OpenPicture(id);

        _machineProvider.SetState(_machineProvider.GetState<HideScrollState_Puzzle>());
    }
}
