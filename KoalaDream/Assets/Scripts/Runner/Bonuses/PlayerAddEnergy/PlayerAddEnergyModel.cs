using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddEnergyModel
{
    private List<IEnergyObstacle> energyObstacles = new List<IEnergyObstacle>();

    private readonly IObstacleSpawnerEventsProvider _obstacleSpawnerEventsProvider;
    private readonly IPlayerEnergyProvider _playerEnergyProvider;
    private readonly IObstacleEventsProvider _obstacleEventsProvider;

    public PlayerAddEnergyModel(IObstacleSpawnerEventsProvider obstacleSpawnerEventsProvider, IPlayerEnergyProvider playerEnergyProvider, IObstacleEventsProvider obstacleEventsProvider)
    {
        _obstacleSpawnerEventsProvider = obstacleSpawnerEventsProvider;
        _playerEnergyProvider = playerEnergyProvider;
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
        if (obstacle is IEnergyObstacle punchObstacle)
        {
            punchObstacle.OnAddEnergy += AddEnergy;

            energyObstacles.Add(punchObstacle);
            Debug.Log("Add Energy");
        }
    }

    private void RemoveObstacle(IObstacle obstacle)
    {
        if (obstacle is IEnergyObstacle punchObstacle)
        {
            punchObstacle.OnAddEnergy -= AddEnergy;

            energyObstacles.Remove(punchObstacle);
            Debug.Log("Remove Energy");
        }
    }

    private void AddEnergy()
    {
        _playerEnergyProvider.AddEnergy(3);
    }
}
