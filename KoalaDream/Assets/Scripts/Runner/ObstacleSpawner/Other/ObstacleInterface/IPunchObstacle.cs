using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPunchObstacle : IObstacle
{
    public event Action<float> OnAddPunch;
}
