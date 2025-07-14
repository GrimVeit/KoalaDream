using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShowExitState_Puzzle : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIGameSceneRoot_Puzzle _sceneRoot;

    private readonly ISoundProvider _soundProvider;
    private readonly ISound _soundBackground;

    private IEnumerator timer;

    public ShowExitState_Puzzle(IGlobalStateMachineProvider globalStateMachineProvider, UIGameSceneRoot_Puzzle sceneRoot, ISoundProvider soundProvider)
    {
        _machineProvider = globalStateMachineProvider;
        _sceneRoot = sceneRoot;
        _soundProvider = soundProvider;

        _soundBackground = _soundProvider.GetSound("Background");
    }

    public void EnterState()
    {
        _sceneRoot.OpenShowExitPanel();

        if(timer != null) Coroutines.Stop(timer);

        timer = Timer(2.5f);
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        _soundBackground.SetVolume(0.2f, 0.6f, 0.2f);
    }
}
