using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScaleState_Puzzle : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly IPuzzleFrameProvider _puzzleFrameProvider;

    private IEnumerator timer;

    public PuzzleScaleState_Puzzle(IGlobalStateMachineProvider globalStateMachineProvider, IPuzzleFrameProvider puzzleFrameProvider)
    {
        _machineProvider = globalStateMachineProvider;
        _puzzleFrameProvider = puzzleFrameProvider;
    }

    public void EnterState()
    {
        _puzzleFrameProvider.ShowScale();

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(2);
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        ChangeStateToShowFullImage();
    }

    private void ChangeStateToShowFullImage()
    {
        _machineProvider.SetState(_machineProvider.GetState<ShowFullImageState_Puzzle>());
    }
}
