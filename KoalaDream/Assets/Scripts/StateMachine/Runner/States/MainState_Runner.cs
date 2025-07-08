using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private readonly UIGameSceneRoot_Runner _gameSceneRootRunner;

    private readonly IBackgroundScrollProvider _backgroundScrollProvider;
    private readonly IObstacleSpawnerProvider _obstacleSpawnerProvider;

    public MainState_Runner(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Runner gameSceneRootRunner, IBackgroundScrollProvider backgroundScrollProvider, IObstacleSpawnerProvider obstacleSpawnerProvider)
    {
        _machineProvider = machineProvider;
        _gameSceneRootRunner = gameSceneRootRunner;
        _backgroundScrollProvider = backgroundScrollProvider;
        _obstacleSpawnerProvider = obstacleSpawnerProvider;
    }

    public void EnterState()
    {
        _gameSceneRootRunner.OpenBalancePanel();
        _gameSceneRootRunner.OpenEnergyPanel();

        _backgroundScrollProvider.ActivateScroll();
        _obstacleSpawnerProvider.ActivateSpawner();
    }

    public void ExitState()
    {
        _gameSceneRootRunner.CloseBalancePanel();
        _gameSceneRootRunner.CloseEnergyPanel();
    }
}
