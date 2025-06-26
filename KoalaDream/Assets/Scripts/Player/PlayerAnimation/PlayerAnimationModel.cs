using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationModel
{
    private readonly IPlayerDirectionEventsProvider _playerDirectionEventsProvider;

    public PlayerAnimationModel(IPlayerDirectionEventsProvider playerDirectionEventsProvider)
    {
        _playerDirectionEventsProvider = playerDirectionEventsProvider;

        _playerDirectionEventsProvider.OnChangeDirection += ChangeState;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _playerDirectionEventsProvider.OnChangeDirection -= ChangeState;
    }

    private void ChangeState(int state)
    {
        OnChangeState?.Invoke(state);
    }

    #region Output

    public event Action<int> OnChangeState;

    #endregion
}
