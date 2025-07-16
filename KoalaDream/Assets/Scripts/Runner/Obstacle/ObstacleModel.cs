using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleModel
{
    private readonly IObstacleSpawnerEventsProvider _obstacleSpawnerEventsProvider;

    public ObstacleModel(IObstacleSpawnerEventsProvider obstacleSpawnerEventsProvider)
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

    public event Action<IMoveObstacle> OnAddObstacle;
    public event Action<IObstacle> OnRemoveObstacle;

    private void AddObstacle(IObstacle obstacle)
    {
        var moveObstacle = obstacle as IMoveObstacle;

        OnAddObstacle?.Invoke(moveObstacle);
    }

    public void RemoveObstacle(IObstacle obstacle)
    {
        OnRemoveObstacle?.Invoke(obstacle);
    }
}
