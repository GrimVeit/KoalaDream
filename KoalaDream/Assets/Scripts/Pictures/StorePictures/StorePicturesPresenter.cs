using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePicturesPresenter : IStorePicturesOpenCloseEventsProvider
{
    private readonly StorePicturesModel _model;

    public StorePicturesPresenter(StorePicturesModel model)
    {
        _model = model;
    }

    public void Initialize()
    {
        _model.Initialize();
    }

    public void Dispose()
    {
        _model.Dispose();
    }

    #region Output

    public event Action<int> OnOpenPicture
    {
        add => _model.OnOpenPicture += value;
        remove => _model.OnOpenPicture -= value;
    }

    public event Action<int> OnClosePicture
    {
        add => _model.OnClosePicture += value;
        remove => _model.OnClosePicture -= value;
    }

    #endregion
}

public interface IStorePicturesOpenCloseEventsProvider
{
    public event Action<int> OnOpenPicture;
    public event Action<int> OnClosePicture;
}
