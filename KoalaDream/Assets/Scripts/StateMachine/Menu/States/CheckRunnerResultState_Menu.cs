using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRunnerResultState_Menu : IState
{
    private IGlobalStateMachineProvider _globalStateMachineProvider;
    private UIMainMenuRoot _sceneRoot;

    public CheckRunnerResultState_Menu(IGlobalStateMachineProvider globalStateMachineProvider, UIMainMenuRoot sceneRoot)
    {
        _globalStateMachineProvider = globalStateMachineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToExit_RunnerResult += ChangeStateToExit;
        _sceneRoot.OnClickToRestart_RunnerResult += ChangeStateToRestart;
        _sceneRoot.OnClickToGallery_RunnerResult += ChageStateToGallery;

        _sceneRoot.OpenRunnerResultPanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToExit_RunnerResult -= ChangeStateToExit;
        _sceneRoot.OnClickToRestart_RunnerResult -= ChangeStateToRestart;
        _sceneRoot.OnClickToGallery_RunnerResult -= ChageStateToGallery;

        _sceneRoot.CloseRunnerResultPanel();
    }

    private void ChangeStateToExit()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<FromAutoToManualState_Menu>());
    }

    private void ChangeStateToRestart()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<WalkToStartBedState_Menu>());
    }

    private void ChageStateToGallery()
    {
        _globalStateMachineProvider.SetState(_globalStateMachineProvider.GetState<WalkToPictureState_Menu>());
    }
}
