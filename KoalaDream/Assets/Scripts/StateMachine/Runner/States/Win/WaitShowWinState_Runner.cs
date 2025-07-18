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

    private readonly IPlayerRunnerMoveFreezeProvider _playerRunnerMoveFreezeProvider;
    private readonly IPlayerRunnerMoveAutoProvider _playerRunnerMoveAutoProvider;
    private readonly IPlayerRunnerMoveAutoEventsProvider _playerRunnerMoveAutoEventsProvider;

    public WaitShowWinState_Runner(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Runner sceneRoot, IBackgroundScrollProvider backgroundScrollProvider, IObstacleSpawnerProvider obstacleSpawnerProvider, ILeafEffectProvider leafEffectProvider, IPlayerRunnerMoveFreezeProvider playerRunnerMoveFreezeProvider, IPlayerRunnerMoveAutoProvider playerRunnerMoveAutoProvider, IPlayerRunnerMoveAutoEventsProvider playerRunnerMoveAutoEventsProvider)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _backgroundScrollProvider = backgroundScrollProvider;
        _obstacleSpawnerProvider = obstacleSpawnerProvider;
        _leafEffectProvider = leafEffectProvider;
        _playerRunnerMoveFreezeProvider = playerRunnerMoveFreezeProvider;
        _playerRunnerMoveAutoProvider = playerRunnerMoveAutoProvider;
        _playerRunnerMoveAutoEventsProvider = playerRunnerMoveAutoEventsProvider;
    }

    public void EnterState()
    {
        _playerRunnerMoveAutoEventsProvider.OnMovePlayerToEndGamePosition += ChangeStateToShowWin;

        _sceneRoot.CloseBalancePanel();
        _sceneRoot.CloseEnergyPanel();

        _backgroundScrollProvider.DeactivateScroll();
        _obstacleSpawnerProvider.DeactivateSpawner();
        _leafEffectProvider.DeactivateLeafTimer();

        _playerRunnerMoveFreezeProvider.Freeze();
        _playerRunnerMoveAutoProvider.MoveToEndGamePosition();
    }

    public void ExitState()
    {
        _playerRunnerMoveAutoEventsProvider.OnMovePlayerToEndGamePosition -= ChangeStateToShowWin;
    }

    private void ChangeStateToShowWin()
    {
        _machineProvider.SetState(_machineProvider.GetState<ShowWinState_Runner>());
    }
}
