using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleSoundModel
{
    private List<ISoundObstacle> soundObstacles = new List<ISoundObstacle>();

    private readonly IObstacleSpawnerEventsProvider _obstacleSpawnerEventsProvider;

    private readonly ISoundProvider _soundProvider;

    public PlayerObstacleSoundModel(IObstacleSpawnerEventsProvider obstacleSpawnerEventsProvider, ISoundProvider soundProvider)
    {
        _obstacleSpawnerEventsProvider = obstacleSpawnerEventsProvider;
        _soundProvider = soundProvider;

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
        if (obstacle is ISoundObstacle soundObstacle)
        {
            soundObstacle.OnAddSound += AddSound;

            soundObstacles.Add(soundObstacle);
            //Debug.Log("Add Energy");
        }
    }

    private void AddSound(string id)
    {
        _soundProvider.PlayOneShot(id);
    }
}
