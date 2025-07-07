using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObstacleKangaroo : MonoBehaviour, IMoveObstacle, IPunchObstacle
{
    //[SerializeField] private protected Collider2D colliderObstacle;
    [SerializeField] private protected Transform transformObstacle;
    [SerializeField] private AnimationFrame animationFrame;
    [SerializeField] private ObstacleCollider obstacleCollider;

    private protected float endX;
    private protected Tween _tweenMove;

    private void Awake()
    {
        animationFrame.Activate(-1);
        obstacleCollider.OnActivate += ActivateAction;
    }

    private void OnDestroy()
    {
        animationFrame.Deactivate();
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
        OnAddPunch?.Invoke();
    }

    #region Input

    public event Action<IMoveObstacle> OnEndMove;

    public event Action OnAddPunch;

    #endregion
}
