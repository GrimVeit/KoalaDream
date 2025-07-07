using System;
using UnityEngine;

public interface IMoveObstacle : IObstacle
{
    public void SetData(Vector3 position);
    public void MoveToEnd();
    public void MoveToClear(Vector3 target, Action OnComplete = null);
    public void Stop();
    public void Destroy();


    public event Action<IMoveObstacle> OnEndMove;
}
