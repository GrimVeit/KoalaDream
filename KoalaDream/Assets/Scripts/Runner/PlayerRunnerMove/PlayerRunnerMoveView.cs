using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerRunnerMoveView : View
{
    [SerializeField] private float upSpeed = 3f;
    [SerializeField] private float downSpeed = -3f;
    [SerializeField] private float speedChangeRate = 7f;

    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform upperLimitTransform;

    [Header("Rotate")]
    [SerializeField] private float tiltUpAngle = 10f;
    [SerializeField] private float tiltDownAngle = -30f;
    [SerializeField] private float tiltSmoothTime = 0.1f;

    [SerializeField] private Transform transformStart;
    [SerializeField] private Transform transformStartGame;
    [SerializeField] private Transform transformEndGame;

    private float currentSpeed = 0f;
    private float targetSpeed = 0;

    private bool isHolding = false;
    private bool isPaused = true;

    private float offsetY = 0f;
    private IEnumerator offsetRoutine;

    private float currentZRotation = 0f;
    private float zRotationVelocity = 0f;

    private float rotateOffsetZ = 0f;
    private IEnumerator offsetRotateRoutine;


    private void Awake()
    {
        rectTransform.localPosition = transformStart.localPosition;
    }

    public void StartUp()
    {
        isHolding = true;
    }

    public void StopUp()
    {
        isHolding = false;
    }

    public void Freeze()
    {
        isPaused = true;
    }

    public void Unfreeze()
    {
        isPaused = false;
    }

    //public void MoveToStart()
    //{
    //    Freeze();

    //    rectTransform.localPosition = transformStart.localPosition;
    //    rectTransform.localEulerAngles = new Vector3(0, 0, -20);

    //    rectTransform.DOLocalRotate(new Vector3(0, 0, -10), 3);
    //    rectTransform.DOLocalMove(transformStartGame.localPosition, 3f).SetEase(Ease.Linear).OnComplete(() =>
    //    {
    //        OnActivateToStart?.Invoke();
    //        Unfreeze();
    //    });
    //}

    //public void StopDistance()
    //{
    //    Freeze();

    //    rectTransform.DOLocalMove(new Vector3(), 3f).SetEase(Ease.Linear).OnComplete(() =>
    //    {
    //        OnActivateToStart?.Invoke();
    //        Unfreeze();
    //    });
    //}

    private void FixedUpdate()
    {
        if(isPaused) return;

        float deltaTime = Time.unscaledDeltaTime;

        targetSpeed = isHolding ? upSpeed : downSpeed;

        Vector2 anchoredPos = rectTransform.localPosition;

        if(anchoredPos.y >= upperLimitTransform.localPosition.y && targetSpeed > 0)
        {
            targetSpeed = 0f;
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, speedChangeRate * deltaTime);

        anchoredPos.y += currentSpeed + offsetY;

        rectTransform.localPosition = anchoredPos;




        float baseTilt = isHolding ?  tiltUpAngle : tiltDownAngle;

        currentZRotation = Mathf.SmoothDampAngle(currentZRotation, baseTilt, ref zRotationVelocity, tiltSmoothTime);


        float totalZRotation = currentZRotation + rotateOffsetZ;

        rectTransform.localRotation = Quaternion.Euler(0, 0, totalZRotation);
    }

    public void ApplyOffset(float amount, float duration)
    {
        if (offsetRoutine != null) Coroutines.Stop(offsetRoutine);
        if(offsetRotateRoutine != null) Coroutines.Stop(offsetRotateRoutine);

        offsetRoutine = OffsetRoutine(amount, duration);
        Coroutines.Start(offsetRoutine);
        if(amount > 0f)
        {
            offsetRotateRoutine = OffsetRotateRoutine(15, 1f);
        }
        else
        {
            offsetRotateRoutine = OffsetRotateRoutine(-15, 1f);
        }

        Coroutines.Start(offsetRotateRoutine);
    }

    private IEnumerator OffsetRotateRoutine(float angle, float duration)
    {
        float half = duration / 2f;
        float t = 0f;

        while (t < half)
        {
            rotateOffsetZ = Mathf.Lerp(0, angle, t/half);
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        t = 0f;

        while(t < half)
        {
            rotateOffsetZ = Mathf.Lerp(angle, 0, t / half);
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        rotateOffsetZ = 0f;
    }

    private IEnumerator OffsetRoutine(float amount, float duration)
    {
        float half = duration / 2f;
        float t = 0f;

        while (t < half)
        {
            offsetY = Mathf.Lerp(0, amount, t / half);
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        t = 0f;

        while (t < half)
        {
            offsetY = Mathf.Lerp(amount, 0, t / half);
            t += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        offsetY = 0f;
    }

    #region Output

    public event Action OnActivateToStart;

    #endregion
}
