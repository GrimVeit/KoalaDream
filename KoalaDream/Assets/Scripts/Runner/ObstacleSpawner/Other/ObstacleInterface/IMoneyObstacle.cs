using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoneyObstacle : IObstacle
{
    public event Action OnAddMoney;
}
