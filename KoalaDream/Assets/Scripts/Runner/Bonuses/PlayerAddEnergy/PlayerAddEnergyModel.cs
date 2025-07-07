using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddEnergyModel
{
    private List<IEnergyObstacle> energyObstacles = new List<IEnergyObstacle>();

    private readonly IObstacleSpawnerEventsProvider _obstacleSpawnerEventsProvider;

    public PlayerAddEnergyModel(IObstacleSpawnerEventsProvider obstacleSpawnerEventsProvider)
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
        if (obstacle is IEnergyObstacle punchObstacle)
        {
            energyObstacles.Add(punchObstacle);
            Debug.Log("Add Energy");
        }
    }
}
