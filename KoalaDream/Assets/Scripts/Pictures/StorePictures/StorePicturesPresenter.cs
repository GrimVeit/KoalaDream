using System;

public class StorePicturesPresenter : IStorePicturesOpenCloseEventsProvider, IStorePicturesSelectEventsProvider, IStorePicturesOpenProvider, IStorePicturesSelectProvider
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

    public event Action<Picture> OnOpenPicture
    {
        add => _model.OnOpenPicture += value;
        remove => _model.OnOpenPicture -= value;
    }

    public event Action<Picture> OnClosePicture
    {
        add => _model.OnClosePicture += value;
        remove => _model.OnClosePicture -= value;
    }



    public event Action<Picture> OnSelectPicture
    {
        add => _model.OnSelectPicture += value;
        remove => _model.OnSelectPicture -= value;
    }

    public event Action<Picture> OnSelectOpenPicture_Value
    {
        add => _model.OnSelectOpenPicture_Value += value;
        remove => _model.OnSelectOpenPicture_Value -= value;
    }

    public event Action<Picture> OnSelectClosePicture_Value
    {
        add => _model.OnSelectClosePicture_Value += value;
        remove => _model.OnSelectClosePicture_Value -= value;
    }

    public event Action OnSelectOpenPicture
    {
        add => _model.OnSelectOpenPicture += value;
        remove => _model.OnSelectOpenPicture -= value;
    }

    public event Action OnSelectClosePicture
    {
        add => _model.OnSelectClosePicture += value;
        remove => _model.OnSelectClosePicture -= value;
    }

    #endregion

    #region Input

    public void OpenPicture(int id)
    {
        _model.OpenPicture(id);
    }

    public void SelectPicture(int id)
    {
        _model.SelectPicture(id);
    }

    #endregion
}

public interface IStorePicturesOpenProvider
{
    public void OpenPicture(int id);
}

public interface IStorePicturesSelectProvider
{
    public void SelectPicture(int id);
}

public interface IStorePicturesOpenCloseEventsProvider
{
    public event Action<Picture> OnOpenPicture;
    public event Action<Picture> OnClosePicture;
}

public interface IStorePicturesSelectEventsProvider
{
    public event Action<Picture> OnSelectPicture;
    public event Action<Picture> OnSelectOpenPicture_Value;
    public event Action<Picture> OnSelectClosePicture_Value;
    public event Action OnSelectOpenPicture;
    public event Action OnSelectClosePicture;
}
