using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnergyObstacle : IObstacle
{
    public event Action OnAddEnergy;
}
