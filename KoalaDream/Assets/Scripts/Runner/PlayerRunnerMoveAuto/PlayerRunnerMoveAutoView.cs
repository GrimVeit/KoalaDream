using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerRunnerMoveAutoView : View
{
    [SerializeField] private RectTransform rectTransform;

    [Header("START - TO START POSITION")]
    [SerializeField] private Transform transformStart;
    [SerializeField] private Transform transformStartGame;

    [Header("FINISH - TO WIN STOP")]
    [SerializeField] private Transform transformEndGame;

    [Header("WIN EXIT - TO END")]
    [SerializeField] private Transform transformWinExit;

    [Header("LOSE EXIT - TO END")]
    [SerializeField] private Transform transformLoseExit;

    public void MoveToStartGamePosition()
    {
        //Freeze();

        rectTransform.localPosition = transformStart.localPosition;
        rectTransform.localEulerAngles = new Vector3(0, 0, -25);

        rectTransform.DOLocalRotate(new Vector3(0, 0, -10), 1.5f);
        rectTransform.DOLocalMove(transformStartGame.localPosition, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            OnMovePlayerToStartGamePosition?.Invoke();
            //Unfreeze();
        });
    }

    public void MoveToEndGamePosition()
    {
        //Freeze();

        rectTransform.DOLocalRotate(new Vector3(0, 0, -10), 0.75f);
        rectTransform.DOLocalMove(new Vector3(transformEndGame.localPosition.x, rectTransform.localPosition.y, rectTransform.localPosition.z), 0.75f).SetEase(Ease.Linear).OnComplete(() =>
        {
            OnMovePlayerToEndGamePosition?.Invoke();
            //Unfreeze();
        });
    }

    public void MoveToWinExitPosition()
    {
        //Freeze();

        rectTransform.DOLocalRotate(new Vector3(0, 0, 0), 3);
        rectTransform.DOLocalMove(transformWinExit.localPosition, 3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            OnMovePlayerToWinExitPosition?.Invoke();
            //Unfreeze();
        });
    }

    public void MoveToLoseExitPosition()
    {
        //Freeze();

        rectTransform.DOLocalRotate(new Vector3(0, 0, -80), 3);
        rectTransform.DOLocalMove(transformLoseExit.localPosition, 3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            OnMovePlayerToLoseExitPosition?.Invoke();
            //Unfreeze();
        });
    }

    #region Output

    public event Action OnMovePlayerToStartGamePosition;
    public event Action OnMovePlayerToEndGamePosition;

    public event Action OnMovePlayerToWinExitPosition;
    public event Action OnMovePlayerToLoseExitPosition;

    #endregion
}
