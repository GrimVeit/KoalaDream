using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameSceneRoot_Runner : UIRoot
{
    [SerializeField] private BalancePanel_Runner balancePanel;
    [SerializeField] private EnergyPanel_Runner energyPanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        balancePanel.Initialize();
        energyPanel.Initialize();
    }

    public void Dispose()
    {
        balancePanel.Dispose();
        energyPanel.Dispose();
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

    #endregion
}
