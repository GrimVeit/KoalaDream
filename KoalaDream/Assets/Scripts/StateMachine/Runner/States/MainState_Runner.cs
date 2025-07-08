using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private readonly UIGameSceneRoot_Runner _gameSceneRootRunner;

    private readonly IBackgroundScrollProvider _backgroundScrollProvider;
    private readonly IObstacleSpawnerProvider _obstacleSpawnerProvider;
    private readonly ILeafEffectProvider _leafEffectProvider;

    private readonly IPlayerAddMoneyEventsProvider _playerAddMoneyEventsProvider;

    public MainState_Runner(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Runner gameSceneRootRunner, IBackgroundScrollProvider backgroundScrollProvider, IObstacleSpawnerProvider obstacleSpawnerProvider, ILeafEffectProvider leafEffectProvider, IPlayerAddMoneyEventsProvider playerAddMoneyEventsProvider)
    {
        _machineProvider = machineProvider;
        _gameSceneRootRunner = gameSceneRootRunner;
        _backgroundScrollProvider = backgroundScrollProvider;
        _obstacleSpawnerProvider = obstacleSpawnerProvider;
        _leafEffectProvider = leafEffectProvider;
        _playerAddMoneyEventsProvider = playerAddMoneyEventsProvider;
    }

    public void EnterState()
    {
        _playerAddMoneyEventsProvider.OnWin += ChangeStateToWin;

        _gameSceneRootRunner.OpenBalancePanel();
        _gameSceneRootRunner.OpenEnergyPanel();

        _backgroundScrollProvider.ActivateScroll();
        _obstacleSpawnerProvider.ActivateSpawner();
        _leafEffectProvider.ActivateLeafTimer();
    }

    public void ExitState()
    {
        _playerAddMoneyEventsProvider.OnWin -= ChangeStateToWin;
    }

    private void ChangeStateToWin()
    {
        _machineProvider.SetState(_machineProvider.GetState<WaitShowWinState_Runner>());
    }
}
