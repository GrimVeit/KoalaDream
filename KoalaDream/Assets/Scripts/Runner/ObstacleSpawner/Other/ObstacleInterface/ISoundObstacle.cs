using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoundObstacle : IObstacle
{
    public event Action<string> OnAddSound;
}
