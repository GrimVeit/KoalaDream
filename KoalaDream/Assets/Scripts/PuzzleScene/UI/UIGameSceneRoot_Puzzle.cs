using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameSceneRoot_Puzzle : UIRoot
{
    [SerializeField] private PuzzlesScrollPanel_Puzzle puzzlesScrollPanel;
    [SerializeField] private FullImagePanel_Puzzle fullImagePanel;
    [SerializeField] private DarkenFullImagePanel_Puzzle darkenFullImagePanel;
    [SerializeField] private ShowGreatPanel_Puzzle showGreatPanel;
    [SerializeField] private ShowExitPanel_Puzzle showExitPanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        puzzlesScrollPanel.Initialize();
        fullImagePanel.Initialize();
        darkenFullImagePanel.Initialize();
        showGreatPanel.Initialize();
        showExitPanel.Initialize();
    }

    public void Dispose()
    {
        puzzlesScrollPanel.Dispose();
        fullImagePanel.Dispose();
        darkenFullImagePanel.Dispose();
        showGreatPanel.Dispose();
        showExitPanel.Dispose();
    }

    public void Activate()
    {
        showExitPanel.OnClickToExit += ClickToExit_ShowExit;
    }

    public void Deactivate()
    {
        showExitPanel.OnClickToExit += ClickToExit_ShowExit;

        if (currentPanel != null)
            CloseOtherPanel(currentPanel);

        CloseShowGreatPanel();
        CloseShowExitPanel();
        CloseDarkenFullImagePanel();
    }


    #region Output

    public event Action OnClickToExit_ShowExit;

    private void ClickToExit_ShowExit()
    {
        OnClickToExit_ShowExit?.Invoke();
    }

    #endregion


    #region Input

    public void OpenPuzzlesScrollPanel()
    {
        OpenOtherPanel(puzzlesScrollPanel);
    }

    public void ClosePuzzlesScrollPanel()
    {
        CloseOtherPanel(puzzlesScrollPanel);
    }




    public void OpenFullImagePanel()
    {
        OpenOtherPanel(fullImagePanel);
    }

    public void CloseFullImagePanel()
    {
        CloseOtherPanel(fullImagePanel);
    }




    public void OpenDarkenFullImagePanel()
    {
        OpenOtherPanel(darkenFullImagePanel);
    }

    public void CloseDarkenFullImagePanel()
    {
        CloseOtherPanel(darkenFullImagePanel);
    }




    public void OpenShowGreatPanel()
    {
        OpenOtherPanel(showGreatPanel);
    }

    public void CloseShowGreatPanel()
    {
        CloseOtherPanel(showGreatPanel);
    }




    public void OpenShowExitPanel()
    {
        OpenOtherPanel(showExitPanel);
    }

    public void CloseShowExitPanel()
    {
        CloseOtherPanel(showExitPanel);
    }

    #endregion
}
