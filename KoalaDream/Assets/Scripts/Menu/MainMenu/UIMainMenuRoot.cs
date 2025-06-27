using System;
using UnityEngine;

public class UIMainMenuRoot : UIRoot
{
    [SerializeField] private ShowPicturePanel_Menu showPicturePanel;
    [SerializeField] private OpenPicturePanel_Menu openPicturePanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        showPicturePanel.Initialize();
        openPicturePanel.Initialize();
    }

    public void Activate()
    {
        showPicturePanel.OnClickToExit += ClickToExit_ShowPicture;
        openPicturePanel.OnClickToExit += ClickToExit_OpenPicture;
    }


    public void Deactivate()
    {
        if (currentPanel != null)
            CloseOtherPanel(currentPanel);

        showPicturePanel.OnClickToExit -= ClickToExit_ShowPicture;
        openPicturePanel.OnClickToExit -= ClickToExit_OpenPicture;
    }

    public void Dispose()
    {
        showPicturePanel.Dispose();
        openPicturePanel.Dispose();
    }




    #region Output


    public event Action OnClickToExit_ShowPicture;

    private void ClickToExit_ShowPicture()
    {
        OnClickToExit_ShowPicture?.Invoke();
    }




    public event Action OnClickToExit_OpenPicture;

    private void ClickToExit_OpenPicture()
    {
        OnClickToExit_OpenPicture?.Invoke();
    }


    #endregion




    #region Input

    public void OpenShowPicturePanel()
    {
        OpenOtherPanel(showPicturePanel);
    }

    public void CloseShowPicturePanel()
    {
        CloseOtherPanel(showPicturePanel);
    }



    public void OpenPicturePanel()
    {
        OpenOtherPanel(openPicturePanel);
    }

    public void ClosePicturePanel()
    {
        CloseOtherPanel(openPicturePanel);
    }

    #endregion
}
