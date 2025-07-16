using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleSoundModel
{
    private List<ISoundObstacle> soundObstacles = new List<ISoundObstacle>();

    private readonly IObstacleSpawnerEventsProvider _obstacleSpawnerEventsProvider;

    private readonly ISoundProvider _soundProvider;
    private readonly IObstacleEventsProvider _obstacleEventsProvider;

    public PlayerObstacleSoundModel(IObstacleSpawnerEventsProvider obstacleSpawnerEventsProvider, ISoundProvider soundProvider, IObstacleEventsProvider obstacleEventsProvider)
    {
        _obstacleSpawnerEventsProvider = obstacleSpawnerEventsProvider;
        _soundProvider = soundProvider;
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
        if (obstacle is ISoundObstacle soundObstacle)
        {
            soundObstacle.OnAddSound += AddSound;

            soundObstacles.Add(soundObstacle);
        }
    }

    private void RemoveObstacle(IObstacle obstacle)
    {
        if (obstacle is ISoundObstacle soundObstacle)
        {
            soundObstacle.OnAddSound -= AddSound;

            soundObstacles.Remove(soundObstacle);
        }
    }

    private void AddSound(string id)
    {
        _soundProvider.PlayOneShot(id);
    }
}
