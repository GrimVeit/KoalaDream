using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState_Puzzle : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Puzzle _sceneRoot;

    private readonly IStorePicturesPreviewProvider _storePicturesPreviewProvider;
    private readonly IPuzzleFrameEventsProvider _puzzleFrameEventsProvider;

    public MainState_Puzzle(IGlobalStateMachineProvider globalStateMachineProvider, UIGameSceneRoot_Puzzle sceneRoot, IStorePicturesPreviewProvider storePicturesPreviewProvider, IPuzzleFrameEventsProvider puzzleFrameEventsProvider)
    {
        _machineProvider = globalStateMachineProvider;
        _sceneRoot = sceneRoot;
        _storePicturesPreviewProvider = storePicturesPreviewProvider;
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
        _storePicturesPreviewProvider.PreviewPicture(id);

        _machineProvider.SetState(_machineProvider.GetState<HideScrollState_Puzzle>());
    }
}
