using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TestAnim : MonoBehaviour
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

    private bool IsMove = false;

    private IEnumerator coro;
    private Tween tweenMove;

    private void Awake()
    {
        Activate();
    }

    public void Activate()
    {
        tweenMove?.Kill();
        if(coro != null ) Coroutines.Stop(coro);

        transformPlayer.position = transformRestart.position;

        IsMove = true;
        tweenMove = transformPlayer.DOLocalMove(transformEndWalk.localPosition, timeWalk).OnComplete(() => IsMove = false);

        coro = MoveToSleep();
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

        yield return new WaitForSeconds(timeWaitLieDown_Anim);

        imagePlayerAnim.sprite = spriteLieDown;

        yield return new WaitForSeconds(3);

        Activate();
    }
}
