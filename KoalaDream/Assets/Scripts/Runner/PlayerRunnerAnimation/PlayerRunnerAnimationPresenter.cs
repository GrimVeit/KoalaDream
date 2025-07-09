using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerAnimationPresenter : IPlayerRunnerAnimationProvider
{
    private readonly PlayerRunnerAnimationView _view;

    public PlayerRunnerAnimationPresenter(PlayerRunnerAnimationView view)
    {
        _view = view;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }


    #region Input

    public void AnimationDown()
    {
        _view.Down();
    }

    #endregion
}

public interface IPlayerRunnerAnimationProvider
{
    void AnimationDown();
}
