using System;
using UnityEngine;

public class UIMainMenuRoot : UIRoot
{
    [SerializeField] private ShowPicturePanel_Menu showPicturePanel;
    [SerializeField] private OpenPicturePanel_Menu openPicturePanel;

    [SerializeField] private RunnerResultPanel_Menu runnerResultPanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        showPicturePanel.Initialize();
        openPicturePanel.Initialize();
        runnerResultPanel.Initialize();
    }

    public void Activate()
    {
        showPicturePanel.OnClickToExit += ClickToExit_ShowPicture;
        openPicturePanel.OnClickToExit += ClickToExit_OpenPicture;

        runnerResultPanel.OnClickToExit += ClickToExit_RunnerResult;
        runnerResultPanel.OnClickToRestart += ClickToRestart_RunnerResult;
        runnerResultPanel.OnClickToGallery += ClickToGallery_RunnerResult;
    }


    public void Deactivate()
    {
        if (currentPanel != null)
            CloseOtherPanel(currentPanel);

        showPicturePanel.OnClickToExit -= ClickToExit_ShowPicture;
        openPicturePanel.OnClickToExit -= ClickToExit_OpenPicture;

        runnerResultPanel.OnClickToExit -= ClickToExit_RunnerResult;
        runnerResultPanel.OnClickToRestart -= ClickToRestart_RunnerResult;
        runnerResultPanel.OnClickToGallery -= ClickToGallery_RunnerResult;
    }

    public void Dispose()
    {
        showPicturePanel.Dispose();
        openPicturePanel.Dispose();
        runnerResultPanel.Dispose();
    }




    #region Output


    public event Action OnClickToExit_ShowPicture;

    private void ClickToExit_ShowPicture()
    {
        _soundProvider.PlayOneShot("Click_Exit");

        OnClickToExit_ShowPicture?.Invoke();
    }




    public event Action OnClickToExit_OpenPicture;

    private void ClickToExit_OpenPicture()
    {
        _soundProvider.PlayOneShot("Click_Exit");

        OnClickToExit_OpenPicture?.Invoke();
    }





    public event Action OnClickToExit_RunnerResult;
    public event Action OnClickToRestart_RunnerResult;
    public event Action OnClickToGallery_RunnerResult;

    private void ClickToExit_RunnerResult()
    {
        _soundProvider.PlayOneShot("Click_Exit");

        OnClickToExit_RunnerResult?.Invoke();
    }

    private void ClickToRestart_RunnerResult()
    {
        OnClickToRestart_RunnerResult?.Invoke();
    }

    private void ClickToGallery_RunnerResult()
    {
        OnClickToGallery_RunnerResult?.Invoke();
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




    public void OpenRunnerResultPanel()
    {
        OpenOtherPanel(runnerResultPanel);
    }

    public void CloseRunnerResultPanel()
    {
        CloseOtherPanel(runnerResultPanel);
    }

    #endregion
}
