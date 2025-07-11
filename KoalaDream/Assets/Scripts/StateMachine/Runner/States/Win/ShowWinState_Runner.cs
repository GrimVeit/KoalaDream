using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWinState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private readonly UIGameSceneRoot_Runner _sceneRoot;

    private IEnumerator timer;

    public ShowWinState_Runner(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Runner sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(2.5f);
        Coroutines.Start(timer);

        _sceneRoot.OpenWinPanel();
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);

        _sceneRoot.CloseWinPanel();
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        ChangeStateToExit();
    }

    private void ChangeStateToExit()
    {
        _machineProvider.SetState(_machineProvider.GetState<WinExitState_Runner>());
    }
}
