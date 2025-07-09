using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCancelState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private UIGameSceneRoot_Runner _sceneRoot;

    private readonly IBackgroundScrollProvider _backgroundScrollProvider;
    private readonly IObstacleSpawnerProvider _obstacleSpawnerProvider;
    private readonly ILeafEffectProvider _leafEffectProvider;

    private readonly IPlayerRunnerMoveFreezeProvider _playerRunnerMoveFreezeProvider;

    private IEnumerator timer;

    public ShowCancelState_Runner(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Runner sceneRoot, IBackgroundScrollProvider backgroundScrollProvider, IObstacleSpawnerProvider obstacleSpawnerProvider, ILeafEffectProvider leafEffectProvider, IPlayerRunnerMoveFreezeProvider playerRunnerMoveFreezeProvider)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _backgroundScrollProvider = backgroundScrollProvider;
        _obstacleSpawnerProvider = obstacleSpawnerProvider;
        _leafEffectProvider = leafEffectProvider;
        _playerRunnerMoveFreezeProvider = playerRunnerMoveFreezeProvider;
    }

    public void EnterState()
    {
        _sceneRoot.CloseBalancePanel();
        _sceneRoot.CloseEnergyPanel();

        _backgroundScrollProvider.DeactivateScroll();
        _obstacleSpawnerProvider.DeactivateSpawner();
        _leafEffectProvider.DeactivateLeafTimer();

        _playerRunnerMoveFreezeProvider.Freeze();
        _sceneRoot.OpenCancelPanel();

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(2.5f);
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        _sceneRoot.CloseCancelPanel();

        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        ChangeStateToCancelExit();
    }

    private void ChangeStateToCancelExit()
    {
        _machineProvider.SetState(_machineProvider.GetState<CancelExitState_Runner>());
    }
}
