using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PicturePuzzleAccessView : View
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private TextMeshProUGUI textNeed;

    public void Initialize()
    {
        buttonPlay.onClick.AddListener(() => OnPlayPuzzle?.Invoke());
    }

    public void Dispose()
    {
        buttonPlay.onClick.RemoveListener(() => OnPlayPuzzle?.Invoke());
    }

    public void Activate()
    {
        buttonPlay.gameObject.SetActive(true);
        textNeed.gameObject.SetActive(false);
    }

    public void Deactivate(int needCost)
    {
        buttonPlay.gameObject.SetActive(false);
        textNeed.gameObject.SetActive(true);

        textNeed.text = $"You need {needCost} more to play";
    }

    #region Output

    public event Action OnPlayPuzzle;

    #endregion
}
