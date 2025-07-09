using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerExitModel
{
    public event Action OnExit;

    public void Exit()
    {
        OnExit?.Invoke();
    }
}
