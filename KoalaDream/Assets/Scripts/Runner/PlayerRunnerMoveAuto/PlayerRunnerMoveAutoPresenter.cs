using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerMoveAutoPresenter : IPlayerRunnerMoveAutoEventsProvider, IPlayerRunnerMoveAutoProvider
{
    private readonly PlayerRunnerMoveAutoView _view;

    public PlayerRunnerMoveAutoPresenter(PlayerRunnerMoveAutoView view)
    {
        _view = view;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    #region Output

    public event Action OnMovePlayerToStartGamePosition
    {
        add => _view.OnMovePlayerToStartGamePosition += value;
        remove => _view.OnMovePlayerToStartGamePosition -= value;
    }

    public event Action OnMovePlayerToEndGamePosition
    {
        add => _view.OnMovePlayerToEndGamePosition += value;
        remove => _view.OnMovePlayerToEndGamePosition -= value;
    }

    #endregion

    #region Input

    public void MoveToStartGamePosition()
    {
        _view.MoveToStartGamePosition();
    }

    public void MoveToEndGamePosition()
    {
        _view.MoveToEndGamePosition();
    }

    public void MoveToWinExitPosition()
    {
        _view.MoveToWinExitPosition();
    }

    public void MoveToLoseExitPosition()
    {
        _view.MoveToLoseExitPosition();
    }



    #endregion
}

public interface IPlayerRunnerMoveAutoEventsProvider
{
    public event Action OnMovePlayerToStartGamePosition;
    public event Action OnMovePlayerToEndGamePosition;
}

public interface IPlayerRunnerMoveAutoProvider
{
    public void MoveToStartGamePosition();
    public void MoveToEndGamePosition();
    public void MoveToWinExitPosition();
    public void MoveToLoseExitPosition();
}
