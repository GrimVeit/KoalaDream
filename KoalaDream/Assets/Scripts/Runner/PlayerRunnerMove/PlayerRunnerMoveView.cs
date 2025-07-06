using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerMoveView : View
{
    [SerializeField] private float upSpeed = 3f;
    [SerializeField] private float downSpeed = -3f;
    [SerializeField] private float speedChangeRate = 7f;

    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform upperLimitTransform;

    private float currentSpeed = 0f;
    private float targetSpeed = 0;

    private bool isHolding = false;

    public void StartTouch()
    {
        isHolding = true;
    }

    public void StopTouch()
    {
        isHolding = false;
    }

    private void FixedUpdate()
    {
        float deltaTime = Time.unscaledDeltaTime;

        targetSpeed = isHolding ? upSpeed : downSpeed;

        Vector2 anchoredPos = rectTransform.localPosition;

        if(anchoredPos.y >= upperLimitTransform.localPosition.y && targetSpeed > 0)
        {
            targetSpeed = 0f;
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, speedChangeRate * deltaTime);

        anchoredPos.y += currentSpeed;

        rectTransform.localPosition = anchoredPos;
    }


}
