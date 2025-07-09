using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleView : View
{
    [SerializeField] private List<Transform> transformClears = new List<Transform>();

    [SerializeField] private List<IMoveObstacle> obstacles = new List<IMoveObstacle>();
    [SerializeField] private Transform transformEnd;

    public void ClearObstacles()
    {
        obstacles.ForEach(o =>
        {
            o.OnEndMove -= RemoveObstacle;

            o.MoveToClear(transformClears[Random.Range(0, transformClears.Count)].position.ToSystemVector(), () => 
            {
                OnDestroyObstacle?.Invoke(o);
                o.Destroy();
            });
        });

        obstacles.Clear();
    }

    public void PauseObstacles()
    {
        obstacles.ForEach(o =>
        {
            o.Pause();
        });
    }

    public void ResumeObstacles()
    {
        obstacles.ForEach(o =>
        {
            o.Resume();
        });
    }

    public void AddObstacle(IMoveObstacle obstacle)
    {
        obstacles.Add(obstacle);

        obstacle.OnEndMove += RemoveObstacle;

        obstacle.SetData(transformEnd.localPosition.ToSystemVector());
        obstacle.MoveToEnd();
    }

    private void RemoveObstacle(IMoveObstacle obstacle)
    {
        OnDestroyObstacle?.Invoke(obstacle);

        obstacles.Remove(obstacle);

        obstacle.OnEndMove -= RemoveObstacle;

        obstacle.Destroy();
    }

    #region Output

    public event Action<IMoveObstacle> OnDestroyObstacle;

    #endregion
}
