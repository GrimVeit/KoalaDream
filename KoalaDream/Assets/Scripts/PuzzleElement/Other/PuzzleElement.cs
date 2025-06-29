using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public event Action<PuzzleElement> OnGrabbing;
    public event Action OnStartMove;
    public event Action<int, Transform> OnEndMove;
    public event Action<Vector2> OnMove;

    public int ID => id;

    [SerializeField] private int id;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public void Initialize()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Dispose()
    {

    }

    #region Methods

    public void Teleport()
    {
        canvasGroup.blocksRaycasts = true;

        rectTransform.localPosition = Vector2.zero;
    }

    public void StartMove()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void EndMove()
    {
        canvasGroup.blocksRaycasts = true;

        rectTransform.DOLocalMove(Vector2.zero, 0.1f);
    }


    public void Move(Vector2 vector)
    {
        rectTransform.anchoredPosition += vector;
    }

    #endregion

    #region Input

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnGrabbing?.Invoke(this);
        OnStartMove?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnMove?.Invoke(eventData.delta);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndMove?.Invoke(id, transform);
    }

    #endregion
}
