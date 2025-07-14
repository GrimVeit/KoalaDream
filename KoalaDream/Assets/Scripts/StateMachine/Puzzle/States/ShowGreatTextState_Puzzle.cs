using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGreatTextState_Puzzle : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Puzzle _sceneRoot;

    private readonly ISoundProvider _soundProvider;
    private readonly ISound _soundBackground;

    private IEnumerator timer;

    public ShowGreatTextState_Puzzle(IGlobalStateMachineProvider globalStateMachineProvider, UIGameSceneRoot_Puzzle sceneRoot, ISoundProvider soundProvider)
    {
        _machineProvider = globalStateMachineProvider;
        _sceneRoot = sceneRoot;
        _soundProvider = soundProvider;

        _soundBackground = _soundProvider.GetSound("Background");
    }

    public void EnterState()
    {
        _sceneRoot.OpenShowGreatPanel();

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(0.2f);
        Coroutines.Start(timer);

        _soundBackground.SetVolume(0.6f, 0.2f, 0.2f);
        _soundProvider.PlayOneShot("Win");
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);

        _soundBackground.SetVolume(0.6f, 0.2f, 0.2f);
        _soundProvider.PlayOneShot("Win");
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
