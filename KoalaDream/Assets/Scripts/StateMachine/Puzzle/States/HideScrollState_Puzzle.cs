using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScrollState_Puzzle : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Puzzle _sceneRoot;

    private IEnumerator timer;

    public HideScrollState_Puzzle(IGlobalStateMachineProvider globalStateMachineProvider, UIGameSceneRoot_Puzzle sceneRoot)
    {
        _machineProvider = globalStateMachineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.ClosePuzzlesScrollPanel();

        if(timer != null) Coroutines.Stop(timer);

        timer = Timer(0.5f);
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        ChangeStateToPuzzleScale();
    }

    private void ChangeStateToPuzzleScale()
    {
        _machineProvider.SetState(_machineProvider.GetState<PuzzleScaleState_Puzzle>());
    }
}
