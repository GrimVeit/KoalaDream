using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchModel
{
    private List<IPunchObstacle> punchObstacles = new List<IPunchObstacle>();

    private readonly IObstacleSpawnerEventsProvider _obstacleSpawnerEventsProvider;
    private readonly IPlayerRunnerForceProvider _playerRunnerForceProvider;
    private readonly IObstacleEventsProvider _obstacleEventsProvider;

    public PlayerPunchModel(IObstacleSpawnerEventsProvider obstacleSpawnerEventsProvider, IPlayerRunnerForceProvider playerRunnerForceProvider, IObstacleEventsProvider obstacleEventsProvider)
    {
        _obstacleSpawnerEventsProvider = obstacleSpawnerEventsProvider;
        _playerRunnerForceProvider = playerRunnerForceProvider;
        _obstacleEventsProvider = obstacleEventsProvider;

        _obstacleSpawnerEventsProvider.OnSpawnObstacle += AddObstacle;
        _obstacleEventsProvider.OnDestroyObstacle += RemoveObstacle;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _obstacleSpawnerEventsProvider.OnSpawnObstacle -= AddObstacle;
        _obstacleEventsProvider.OnDestroyObstacle -= RemoveObstacle;
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

    private void RemoveObstacle(IObstacle obstacle)
    {
        if (obstacle is IPunchObstacle punchObstacle)
        {
            punchObstacle.OnAddPunch -= AddPunch;

            punchObstacles.Remove(punchObstacle);
            Debug.Log("Remove Punch");
        }
    }

    private void AddPunch(float force)
    {
        _playerRunnerForceProvider.ApplyForceOffset(-force, 0.1f);
    }
}
