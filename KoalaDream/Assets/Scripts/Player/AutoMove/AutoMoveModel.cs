using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Examples;
using UnityEngine;

public class AutoMoveModel
{
    private readonly IPlayerMoveEventsProvider _playerMoveEventsProvider;
    private readonly IPlayerMoveProvider _playerMoveProvider;

    private bool isActive = false;
    private readonly float stopTreshold = 0.03f;

    private float _currentTarget = 0;
    private float _currentPlayer;

    public AutoMoveModel(IPlayerMoveEventsProvider playerMoveEventsProvider, IPlayerMoveProvider playerMoveProvider)
    {
        _playerMoveEventsProvider = playerMoveEventsProvider;
        _playerMoveProvider = playerMoveProvider;
    }

    public void Initialize()
    {
        _playerMoveEventsProvider.OnChangePosition += OnPositionChanged;
    }

    public void Dispose()
    {
        _playerMoveEventsProvider.OnChangePosition -= OnPositionChanged;
    }

    public void MoveTo(float target)
    {
        OnStartMove?.Invoke();

        _currentTarget = target;
        isActive = true;
        UpdateDirection();
    }

    private void OnPositionChanged(float currentX)
    {
        _currentPlayer = currentX;

        if (!isActive) return;

        if(_currentTarget == 0) return;

        float diff = _currentTarget - currentX;

        if (Mathf.Abs(diff) < stopTreshold)
        {
            Cancel();
        }
    }

    private void UpdateDirection()
    {
        if (_currentTarget == 0)
        {
            Cancel();
            return;
        }

        float diff = _currentTarget - _currentPlayer;

        if (Mathf.Abs(diff) < stopTreshold)
        {
            Cancel();
            return;
        }

        _playerMoveProvider.Move(Mathf.Sign(diff));
    }

    private void Cancel()
    {
        isActive = false;
        _playerMoveProvider.Move(0);

        OnStopMove?.Invoke();
    }

    #region Output

    public event Action OnStartMove;
    public event Action OnStopMove;

    #endregion
}
