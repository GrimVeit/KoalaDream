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
        _storePicturesOpenCloseEventsProvider.OnPreviewPicture += PreviewPicture;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storePicturesOpenCloseEventsProvider.OnOpenPicture -= OpenPicture;
        _storePicturesOpenCloseEventsProvider.OnClosePicture -= ClosePicture;
        _storePicturesOpenCloseEventsProvider.OnPreviewPicture -= PreviewPicture;
    }

    private void OpenPicture(Picture picture)
    {
        OnOpenPicture?.Invoke(picture.Id);
    }

    private void ClosePicture(Picture picture)
    {
        OnClosePicture?.Invoke(picture.Id);
    }

    private void PreviewPicture(Picture picture)
    {
        OnPreviewPicture?.Invoke(picture.Id);
    }



    #region Output

    public event Action<int> OnOpenPicture;
    public event Action<int> OnPreviewPicture;
    public event Action<int> OnClosePicture;

    #endregion

    #region Input

    public void SelectPicture(int index)
    {
        _storePicturesSelectProvider.SelectPicture(index);
    }

    #endregion
}
