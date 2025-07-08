using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitShowWinState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private UIGameSceneRoot_Runner _sceneRoot;

    private readonly IBackgroundScrollProvider _backgroundScrollProvider;
    private readonly IObstacleSpawnerProvider _obstacleSpawnerProvider;
    private readonly ILeafEffectProvider _leafEffectProvider;

    private IEnumerator timer;

    public WaitShowWinState_Runner(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Runner sceneRoot, IBackgroundScrollProvider backgroundScrollProvider, IObstacleSpawnerProvider obstacleSpawnerProvider)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _backgroundScrollProvider = backgroundScrollProvider;
        _obstacleSpawnerProvider = obstacleSpawnerProvider;
    }

    public void EnterState()
    {
        if(timer != null) Coroutines.Stop(timer);
        timer = Timer(0.3f);
        Coroutines.Start(timer);

        _sceneRoot.CloseBalancePanel();
        _sceneRoot.CloseEnergyPanel();
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        ChangeStateToShowWin();
    }

    private void ChangeStateToShowWin()
    {

    }
}
