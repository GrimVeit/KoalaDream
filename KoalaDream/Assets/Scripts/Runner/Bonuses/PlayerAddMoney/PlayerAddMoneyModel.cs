using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddMoneyModel
{
    private List<IMoneyObstacle> moneyObstacles = new List<IMoneyObstacle>();

    private readonly IObstacleSpawnerEventsProvider _obstacleSpawnerEventsProvider;
    private readonly IMoneyProvider _moneyProvider;

    public PlayerAddMoneyModel(IObstacleSpawnerEventsProvider obstacleSpawnerEventsProvider, IMoneyProvider moneyProvider)
    {
        _obstacleSpawnerEventsProvider = obstacleSpawnerEventsProvider;

        _obstacleSpawnerEventsProvider.OnSpawnObstacle += AddObstacle;
        _moneyProvider = moneyProvider;
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
        if (obstacle is IMoneyObstacle punchObstacle)
        {
            punchObstacle.OnAddMoney += AddMoney;
            moneyObstacles.Add(punchObstacle);
            Debug.Log("Add Money");
        }
    }

    private void AddMoney()
    {
        _moneyProvider.SendMoney(1);
    }
}
