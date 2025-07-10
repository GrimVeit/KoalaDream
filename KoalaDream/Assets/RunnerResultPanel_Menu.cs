using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunnerResultPanel_Menu : MovePanel
{
    [SerializeField] private Button buttonExit;
    [SerializeField] private List<Button> buttonsRestart = new();
    [SerializeField] private List<Button> buttonsGallery = new();

    public override void Initialize()
    {
        base.Initialize();

        buttonExit.onClick.AddListener(() => OnClickToExit?.Invoke());
        buttonsRestart.ForEach(x => x.onClick.AddListener(() => OnClickToRestart?.Invoke()));
        buttonsGallery.ForEach(x => x.onClick.AddListener(() => OnClickToGallery?.Invoke()));
    }

    public override void Dispose()
    {
        base.Dispose();

        buttonExit.onClick.RemoveListener(() => OnClickToExit?.Invoke());
        buttonsRestart.ForEach(x => x.onClick.RemoveListener(() => OnClickToRestart?.Invoke()));
        buttonsGallery.ForEach(x => x.onClick.RemoveListener(() => OnClickToGallery?.Invoke()));
    }

    #region Output

    public event Action OnClickToExit;
    public event Action OnClickToRestart;
    public event Action OnClickToGallery;

    #endregion
}
