using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawnerView : View
{
    [SerializeField] private ObstacleSpawnChance spawnChance;
    [SerializeField] private Transform transformParent;
    [SerializeField] private List<PathRouteData> spawnPoints = new List<PathRouteData>();

    public void SpawnObstacle(int id)
    {
        var data = spawnPoints.FirstOrDefault(d => d.Id == id);

        var obstaclePrefab = spawnChance.GetRandomObstacle();

        var obstacleObject = Instantiate(obstaclePrefab, transformParent);
        obstacleObject.transform.SetLocalPositionAndRotation(data.StartPoint.localPosition, obstaclePrefab.transform.rotation);
        var obstacle = obstacleObject.GetComponent<IObstacle>();

        OnSpawnObstacle?.Invoke(obstacle);
    }

    #region Output

    public event Action<IObstacle> OnSpawnObstacle;

    #endregion
}

[System.Serializable]
public class PathRouteData
{
    [SerializeField] private int id;
    [SerializeField] private Transform transformStartPoint;

    public int Id => id;
    public Transform StartPoint => transformStartPoint;
}
