using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameSceneRoot_Runner : UIRoot
{
    [SerializeField] private BalancePanel_Runner balancePanel;
    [SerializeField] private EnergyPanel_Runner energyPanel;

    [SerializeField] private WinPanel_Runner winPanel;
    [SerializeField] private LosePanel_Runner losePanel;
    [SerializeField] private ExitPanel_Runner exitPanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        balancePanel.Initialize();
        energyPanel.Initialize();

        winPanel.Initialize();
        losePanel.Initialize();
        exitPanel.Initialize();
    }

    public void Dispose()
    {
        balancePanel.Dispose();
        energyPanel.Dispose();

        winPanel.Dispose();
        losePanel.Dispose();
        exitPanel.Dispose();
    }

    public void Activate()
    {
        balancePanel.OnClickToExit += ClickToExit_Balance;
    }

    public void Deactivate()
    {
        balancePanel.OnClickToExit -= ClickToExit_Balance;

        if (currentPanel != null)
            CloseOtherPanel(currentPanel);
    }


    #region Output

    public event Action OnClickToExit_Balance;

    private void ClickToExit_Balance()
    {
        OnClickToExit_Balance?.Invoke();
    }

    #endregion


    #region Input

    public void OpenBalancePanel()
    {
        OpenOtherPanel(balancePanel);
    }

    public void CloseBalancePanel()
    {
        CloseOtherPanel(balancePanel);
    }



    public void OpenEnergyPanel()
    {
        OpenOtherPanel(energyPanel);
    }

    public void CloseEnergyPanel()
    {
        CloseOtherPanel(energyPanel);
    }




    public void OpenWinPanel()
    {
        OpenOtherPanel(winPanel);
    }

    public void CloseWinPanel()
    {
        CloseOtherPanel(winPanel);
    }


    public void OpenLosePanel()
    {
        OpenOtherPanel(losePanel);
    }

    public void CloseLosePanel()
    {
        CloseOtherPanel(losePanel);
    }


    public void OpenExitPanel()
    {
        OpenOtherPanel(exitPanel);
    }

    public void CloseExitPanel()
    {
        CloseOtherPanel(exitPanel);
    }

    #endregion
}
