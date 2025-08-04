using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowPicturePanel_Menu : MoveRotateScalePanel
{
    [SerializeField] private Button buttonExit;

    public override void Initialize()
    {
        base.Initialize();

        buttonExit.onClick.AddListener(() => OnClickToExit?.Invoke());
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonExit.onClick.RemoveListener(() => OnClickToExit?.Invoke());
    }

    #region Output

    public event Action OnClickToExit;

    #endregion
}
