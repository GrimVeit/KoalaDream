using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleCloud : MonoBehaviour, IMoveObstacle, IPunchObstacle
{
    //[SerializeField] private protected Collider2D colliderObstacle;
    [SerializeField] private protected Transform transformObstacle;
    [SerializeField] private AnimationFrame animationFrame;
    [SerializeField] private ObstacleCollider obstacleCollider;
    [SerializeField] private float forcePunch;

    private protected float endX;
    private protected Tween _tweenMove;
    private Sequence sequenceClose;
    private bool isActivate = false;

    private void Awake()
    {
        animationFrame.Activate(-1);
        obstacleCollider.OnActivate += ActivateAction;
    }

    private void OnDestroy()
    {
        sequenceClose?.Kill();

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

    public void Pause()
    {
        _tweenMove?.Pause();
    }

    public void Resume()
    {
        _tweenMove?.Play();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void ActivateAction()
    {
        if(isActivate) return;

        OnAddPunch?.Invoke(forcePunch);

        sequenceClose = DOTween.Sequence();

        sequenceClose
            .Append(transformObstacle.DOScale(1.1f, 0.1f))
            .Append(transformObstacle.DOScale(0, 0.2f))
            .Join(transformObstacle.DOLocalRotate(new Vector3(0, 0, GetRandomAngle()), 0.2f));

        isActivate = true;
    }

    private float GetRandomAngle()
    {
        bool positive = Random.value > 0.5f;

        if (positive)
            return Random.Range(180f, 360);
        else
            return Random.Range(-360f, -180f);
    }

    #region Input

    public event Action<IMoveObstacle> OnEndMove;

    public event Action<float> OnAddPunch;

    #endregion
}
