using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerGameResultVisualView : View
{
    [SerializeField] private List<RunnerGameResultVisual> resultVisuals = new();

    public void SetRunnerResult(RunnerResult runnerResult)
    {
        resultVisuals.ForEach(data =>
        {
            if(data.RunnerResult != runnerResult)
            {
                data.ObjectPanel.SetActive(false);
            }
            else
            {
                data.ObjectPanel.SetActive(true);
            }
        });
    }
}

[Serializable]
public class RunnerGameResultVisual
{
    [SerializeField] private RunnerResult runnerResult;
    [SerializeField] private GameObject objectPanel;

    public RunnerResult RunnerResult => runnerResult;
    public GameObject ObjectPanel => objectPanel;
}
