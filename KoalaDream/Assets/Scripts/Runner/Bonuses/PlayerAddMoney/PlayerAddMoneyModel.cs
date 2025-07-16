using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddMoneyModel
{
    private List<IMoneyObstacle> moneyObstacles = new List<IMoneyObstacle>();

    private readonly IObstacleSpawnerEventsProvider _obstacleSpawnerEventsProvider;
    private readonly IMoneyProvider _moneyProvider;
    private readonly IRunnerResultMoneyProvider _runnerResultMoneyProvider;
    private readonly IObstacleEventsProvider _obstacleEventsProvider;

    private const int _winMoney = 5;
    private int _currentMoney;

    public PlayerAddMoneyModel(IObstacleSpawnerEventsProvider obstacleSpawnerEventsProvider, IMoneyProvider moneyProvider, IRunnerResultMoneyProvider runnerResultMoneyProvider, IObstacleEventsProvider obstacleEventsProvider)
    {
        _obstacleSpawnerEventsProvider = obstacleSpawnerEventsProvider;
        _moneyProvider = moneyProvider;
        _runnerResultMoneyProvider = runnerResultMoneyProvider;
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
        if (obstacle is IMoneyObstacle punchObstacle)
        {
            punchObstacle.OnAddMoney += AddMoney;
            moneyObstacles.Add(punchObstacle);
            Debug.Log("Add Money");
        }
    }

    private void RemoveObstacle(IObstacle obstacle)
    {
        if (obstacle is IMoneyObstacle punchObstacle)
        {
            punchObstacle.OnAddMoney -= AddMoney;
            moneyObstacles.Remove(punchObstacle);
            Debug.Log("Remove Money");
        }
    }

    private void AddMoney()
    {
        _currentMoney += 1;
        _moneyProvider.SendMoney(1);
        _runnerResultMoneyProvider.AddMoney(1);
        if(_currentMoney >= _winMoney)
        {
            OnWin?.Invoke();
        }
    }

    #region Output

    public event Action OnWin;

    #endregion
}
