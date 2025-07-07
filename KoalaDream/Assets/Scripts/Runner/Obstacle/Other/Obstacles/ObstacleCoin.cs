using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleCoin : MonoBehaviour, IMoveObstacle, IMoneyObstacle
{
    //[SerializeField] private protected Collider2D colliderObstacle;
    [SerializeField] private protected Transform transformObstacle;
    [SerializeField] private ObstacleCollider obstacleCollider;

    [Header("Effect")]
    [SerializeField] private Transform transformSprite;
    [SerializeField] private Image imageEffect;
    [SerializeField] private Sprite spriteEffect_1;
    [SerializeField] private Sprite spriteEffect_2;

    private protected float endX;
    private protected Tween _tweenMove;

    private IEnumerator timer;

    private void Awake()
    {
        obstacleCollider.OnActivate += ActivateAction;
    }

    private void OnDestroy()
    {
        if (timer != null) Coroutines.Stop(timer);

        obstacleCollider.OnActivate -= ActivateAction;
    }

    public void SetData(System.Numerics.Vector3 vector)
    {
        endX = vector.ToUnityVector().x;
    }
    public void MoveToEnd()
    {
        _tweenMove = transformObstacle.DOLocalMove(new Vector3(endX, transform.localPosition.y, transform.localPosition.z), 4f).SetEase(Ease.Linear).OnComplete(() => OnEndMove?.Invoke(this));
    }

    public void MoveToClear(System.Numerics.Vector3 target, Action OnComplete = null)
    {
        _tweenMove?.Kill();

        _tweenMove = transformObstacle.DOMove(target.ToUnityVector(), 1f).OnComplete(() => OnComplete?.Invoke());
    }

    public void Stop()
    {
        _tweenMove?.Kill();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void ActivateAction()
    {
        OnAddMoney?.Invoke();

        if(timer != null) Coroutines.Stop(timer);

        timer = Timer();
        Coroutines.Start(timer);
    }

    private IEnumerator Timer()
    {
        imageEffect.gameObject.SetActive(true);
        imageEffect.transform.localScale = Vector3.zero;
        imageEffect.sprite = spriteEffect_1;

        imageEffect.transform.DOScale(0.5f, 0.1f);

        yield return new WaitForSeconds(0.1f);

        imageEffect.sprite = spriteEffect_2;
        imageEffect.transform.DOScale(1, 0.2f);

        yield return new WaitForSeconds(0.2f);

        transformSprite.DOScale(0, 0.2f);
        imageEffect.transform.DOScale(0, 0.2f);
    }

    #region Input

    public event Action<IMoveObstacle> OnEndMove;

    public event Action OnAddMoney;

    #endregion
}
