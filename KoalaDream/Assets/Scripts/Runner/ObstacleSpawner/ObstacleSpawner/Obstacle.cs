using System;
using DG.Tweening;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour, IMoveObstacle
{
    [SerializeField] private protected Collider2D colliderObstacle;
    [SerializeField] private protected Transform transformObstacle;
    [SerializeField] private protected Transform transformRandomLeft;
    [SerializeField] private protected Transform transformRandomRight;

    private protected float endX;
    private protected Tween _tweenMove;

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

    #region Input

    public event Action<IMoveObstacle> OnEndMove;

    #endregion
}
