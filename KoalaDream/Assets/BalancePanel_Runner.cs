using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalancePanel_Runner : MoveRotatePanel
{
    [SerializeField] private Button buttonExit;

    public override void Initialize()
    {
        base.Initialize();

        buttonExit.onClick.AddListener(() => OnClickToCancel?.Invoke());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonExit.onClick.RemoveListener(() => OnClickToCancel?.Invoke());
    }

    #region Output

    public event Action OnClickToCancel;

    #endregion
}
