using System;
using UnityEngine;
using UnityEngine.UI;

public class BedGameAccessView : View
{
    [SerializeField] private Button buttonPlay;

    public void Initialize()
    {
        buttonPlay.onClick.AddListener(() => OnActivateGame?.Invoke());
    }

    public void Dispose()
    {
        buttonPlay.onClick.RemoveListener(() => OnActivateGame?.Invoke());
    }

    #region Output

    public event Action OnActivateGame;

    #endregion
}
