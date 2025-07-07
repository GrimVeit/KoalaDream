using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchModel
{
    private List<IPunchObstacle> punchObstacles = new List<IPunchObstacle>();

    private readonly IObstacleSpawnerEventsProvider _obstacleSpawnerEventsProvider;

    public PlayerPunchModel(IObstacleSpawnerEventsProvider obstacleSpawnerEventsProvider)
    {
        _obstacleSpawnerEventsProvider = obstacleSpawnerEventsProvider;

        _obstacleSpawnerEventsProvider.OnSpawnObstacle += AddObstacle;
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
            punchObstacles.Add(punchObstacle);
            Debug.Log("Add Punch");
        }
    }
}
