using System;

public class PicturesVisualModel
{
    private readonly IStorePicturesOpenCloseEventsProvider _storePicturesOpenCloseEventsProvider;
    private readonly IStorePicturesSelectProvider _storePicturesSelectProvider;

    public PicturesVisualModel(IStorePicturesOpenCloseEventsProvider storePicturesOpenCloseEventsProvider, IStorePicturesSelectProvider storePicturesSelectProvider)
    {
        _storePicturesOpenCloseEventsProvider = storePicturesOpenCloseEventsProvider;
        _storePicturesSelectProvider = storePicturesSelectProvider;

        _storePicturesOpenCloseEventsProvider.OnOpenPicture += OpenPicture;
        _storePicturesOpenCloseEventsProvider.OnClosePicture += ClosePicture;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storePicturesOpenCloseEventsProvider.OnOpenPicture -= OpenPicture;
        _storePicturesOpenCloseEventsProvider.OnClosePicture -= ClosePicture;
    }

    private void OpenPicture(Picture picture)
    {
        OnOpenPicture?.Invoke(picture.Id);
    }

    private void ClosePicture(Picture picture)
    {
        OnClosePicture?.Invoke(picture.Id);
    }



    #region Output

    public event Action<int> OnOpenPicture;
    public event Action<int> OnClosePicture;

    #endregion

    #region Input

    public void SelectPicture(int index)
    {
        _storePicturesSelectProvider.SelectPicture(index);
    }

    #endregion
}
