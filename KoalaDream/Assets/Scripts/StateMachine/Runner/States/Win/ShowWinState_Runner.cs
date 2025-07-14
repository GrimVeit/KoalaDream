using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWinState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private readonly UIGameSceneRoot_Runner _sceneRoot;

    private readonly ISoundProvider _soundProvider;
    private readonly ISound _soundBackground;

    private IEnumerator timer;

    public ShowWinState_Runner(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Runner sceneRoot, ISoundProvider soundProvider)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _soundProvider = soundProvider;

        _soundBackground = _soundProvider.GetSound("Background");
    }

    public void EnterState()
    {
        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(2.5f);
        Coroutines.Start(timer);

        _sceneRoot.OpenWinPanel();

        _soundBackground.SetVolume(0.6f, 0.2f, 0.2f);
        _soundProvider.PlayOneShot("Win");
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);

        _sceneRoot.CloseWinPanel();

        _soundBackground.SetVolume(0.2f, 0.6f, 0.2f);
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
