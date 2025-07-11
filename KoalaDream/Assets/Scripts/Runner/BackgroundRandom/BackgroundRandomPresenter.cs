using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRandomPresenter : IBackgroundRandomProvider
{
    private readonly BackgroundRandomView _view;

    public BackgroundRandomPresenter(BackgroundRandomView view)
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

    public void Random()
    {
        _view.RandomBackground();
    }

    #endregion
}

public interface IBackgroundRandomProvider
{
    public void Random();
}
