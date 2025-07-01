using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFullImageState_Puzzle : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Puzzle _sceneRoot;

    private IEnumerator timer;

    public ShowFullImageState_Puzzle(IGlobalStateMachineProvider globalStateMachineProvider, UIGameSceneRoot_Puzzle sceneRoot)
    {
        _machineProvider = globalStateMachineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OpenFullImagePanel();

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(4);
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        ChangeStateToDarkenFullImage();
    }

    private void ChangeStateToDarkenFullImage()
    {
        _machineProvider.SetState(_machineProvider.GetState<DarkenFullImageState_Puzzle>());
    }
}
