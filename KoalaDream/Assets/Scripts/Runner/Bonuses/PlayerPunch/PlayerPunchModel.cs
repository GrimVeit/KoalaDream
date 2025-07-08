using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchModel
{
    private List<IPunchObstacle> punchObstacles = new List<IPunchObstacle>();

    private readonly IObstacleSpawnerEventsProvider _obstacleSpawnerEventsProvider;
    private readonly IPlayerRunnerForceProvider _playerRunnerForceProvider;

    public PlayerPunchModel(IObstacleSpawnerEventsProvider obstacleSpawnerEventsProvider, IPlayerRunnerForceProvider playerRunnerForceProvider)
    {
        _obstacleSpawnerEventsProvider = obstacleSpawnerEventsProvider;

        _obstacleSpawnerEventsProvider.OnSpawnObstacle += AddObstacle;
        _playerRunnerForceProvider = playerRunnerForceProvider;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _obstacleSpawnerEventsProvider.OnSpawnObstacle -= AddObstacle;
    }

    private void AddObstacle(IObstacle obstacle)
    {
        if (obstacle is IPunchObstacle punchObstacle)
        {
            punchObstacle.OnAddPunch += AddPunch;

            punchObstacles.Add(punchObstacle);
            Debug.Log("Add Punch");
        }
    }

    private void AddPunch(float force)
    {
        _playerRunnerForceProvider.ApplyForceOffset(-force, 0.1f);
    }
}
