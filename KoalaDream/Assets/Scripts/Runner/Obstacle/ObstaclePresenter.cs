using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePresenter : IObstacleEventsProvider
{
    private readonly ObstacleModel _model;
    private readonly ObstacleView _view;

    public ObstaclePresenter(ObstacleModel model, ObstacleView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _model.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _model.Dispose();
    }

    private void ActivateEvents()
    {
        _view.OnDestroyObstacle += _model.RemoveObstacle;

        _model.OnAddObstacle += _view.AddObstacle;
    }

    private void DeactivateEvents()
    {
        _view.OnDestroyObstacle -= _model.RemoveObstacle;

        _model.OnAddObstacle -= _view.AddObstacle;
    }

    #region Input

    //public void AddObstacle(IMoveObstacle obstacle)
    //{
    //    _view.AddObstacle(obstacle);
    //}

    public void PauseObstacles()
    {
        _view.PauseObstacles();
    }

    public void ResumeObstacles()
    {
        _view.ResumeObstacles();
    }

    public void ClearObstacles()
    {
        _view.ClearObstacles();
    }

    #endregion

    #region Output

    public event Action<IObstacle> OnDestroyObstacle
    {
        add => _view.OnDestroyObstacle += value;
        remove => _view.OnDestroyObstacle -= value;
    }

    #endregion
}

public interface IObstacleEventsProvider
{
    public event Action<IObstacle> OnDestroyObstacle;
}

public interface IObstacleProvider
{
    public void PauseObstacles();
    public void ResumeObstacles();
    public void ClearObstacles();

}
