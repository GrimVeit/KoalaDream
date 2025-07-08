using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddEnergyModel
{
    private List<IEnergyObstacle> energyObstacles = new List<IEnergyObstacle>();

    private readonly IObstacleSpawnerEventsProvider _obstacleSpawnerEventsProvider;

    private readonly IPlayerEnergyProvider _playerEnergyProvider;

    public PlayerAddEnergyModel(IObstacleSpawnerEventsProvider obstacleSpawnerEventsProvider, IPlayerEnergyProvider playerEnergyProvider)
    {
        _obstacleSpawnerEventsProvider = obstacleSpawnerEventsProvider;

        _obstacleSpawnerEventsProvider.OnSpawnObstacle += AddObstacle;
        _playerEnergyProvider = playerEnergyProvider;
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
            punchObstacle.OnAddEnergy += AddEnergy;

            energyObstacles.Add(punchObstacle);
            Debug.Log("Add Energy");
        }
    }

    private void AddEnergy()
    {
        _playerEnergyProvider.AddEnergy(3);
    }
}
