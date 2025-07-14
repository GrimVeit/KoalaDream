using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerSleepAnimationView : View
{
    [Header("Animation")]
    [SerializeField] private List<Sprite> spritesMove = new();
    [SerializeField] private Sprite spriteSitDawn;
    [SerializeField] private Sprite spriteLieDown;
    [SerializeField] private SpriteRenderer imagePlayerAnim;

    [Header("Transform")]
    [SerializeField] private Transform transformPlayer;
    [SerializeField] private Transform transformEndWalk;
    [SerializeField] private Transform transformLieDownAndSitDown;
    [SerializeField] private Transform transformRestart;

    [Header("Time")]
    [SerializeField] private float timeWalk;
    [SerializeField] private float timeWaitDelayWalk_Anim;
    [SerializeField] private float timeWaitLieDown_Anim;
    [SerializeField] private float timeSleep;

    private bool IsMove = false;

    private IEnumerator coro;
    private Tween tweenMove;

    public void Activate()
    {
        tweenMove?.Kill();
        if (coro != null) Coroutines.Stop(coro);

        transformPlayer.gameObject.SetActive(true);

        transformPlayer.position = transformRestart.position;

        IsMove = true;
        tweenMove = transformPlayer.DOLocalMove(transformEndWalk.localPosition, timeWalk).OnComplete(() => IsMove = false);

        coro = MoveToSleep();
        Coroutines.Start(coro);
    }

    public void Deactivate()
    {
        tweenMove?.Kill();
        if (coro != null) Coroutines.Stop(coro);

        transformPlayer.gameObject.SetActive(true);

        coro = MoveToWakeUp();
        Coroutines.Start(coro);
    }

    private IEnumerator MoveToSleep()
    {
        int index = 0;
        imagePlayerAnim.flipX = true;

        while (IsMove)
        {
            imagePlayerAnim.sprite = spritesMove[index];

            index++;

            if (index >= spritesMove.Count)
                index = 0;

            yield return new WaitForSeconds(timeWaitDelayWalk_Anim);
        }

        imagePlayerAnim.flipX = false;

        transformPlayer.localPosition = transformLieDownAndSitDown.localPosition;
        imagePlayerAnim.sprite = spriteSitDawn;

        OnSitBedroom?.Invoke();

        yield return new WaitForSeconds(timeWaitLieDown_Anim);

        imagePlayerAnim.sprite = spriteLieDown;

        OnHrap?.Invoke();

        yield return new WaitForSeconds(timeSleep);

        OnEndActivate?.Invoke();
    }

    private IEnumerator MoveToWakeUp()
    {
        transformPlayer.localPosition = transformLieDownAndSitDown.localPosition;
        imagePlayerAnim.sprite = spriteLieDown;

        yield return new WaitForSeconds(0.4f);

        imagePlayerAnim.flipX = true;

        imagePlayerAnim.sprite = spriteSitDawn;

        OnSitBedroom?.Invoke();

        yield return new WaitForSeconds(timeWaitLieDown_Anim);

        IsMove = true;
        tweenMove = transformPlayer.DOLocalMove(transformRestart.localPosition, timeWalk).OnComplete(() => IsMove = false);

        int index = 0;
        imagePlayerAnim.flipX = false;

        while (IsMove)
        {
            imagePlayerAnim.sprite = spritesMove[index];

            index++;

            if (index >= spritesMove.Count)
                index = 0;

            yield return new WaitForSeconds(timeWaitDelayWalk_Anim);
        }

        transformPlayer.gameObject.SetActive(false);

        OnEndDeactivate?.Invoke();
    }

    #region Output

    public event Action OnEndActivate;
    public event Action OnEndDeactivate;

    public event Action OnHrap;
    public event Action OnSitBedroom;

    #endregion
}
