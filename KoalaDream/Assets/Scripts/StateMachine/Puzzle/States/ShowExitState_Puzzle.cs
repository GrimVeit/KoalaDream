using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowExitState_Puzzle : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Puzzle _sceneRoot;

    public ShowExitState_Puzzle(IGlobalStateMachineProvider globalStateMachineProvider, UIGameSceneRoot_Puzzle sceneRoot)
    {
        _machineProvider = globalStateMachineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OpenShowExitPanel();
    }

    public void ExitState()
    {

    }
}
