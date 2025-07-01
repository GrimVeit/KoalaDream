using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGreatTextState_Puzzle : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Puzzle _sceneRoot;

    private IEnumerator timer;

    public ShowGreatTextState_Puzzle(IGlobalStateMachineProvider globalStateMachineProvider, UIGameSceneRoot_Puzzle sceneRoot)
    {
        _machineProvider = globalStateMachineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OpenShowGreatPanel();

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(0.2f);
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        ChangeStateToShowExit();
    }

    private void ChangeStateToShowExit()
    {
        _machineProvider.SetState(_machineProvider.GetState<ShowExitState_Puzzle>());
    }
}
