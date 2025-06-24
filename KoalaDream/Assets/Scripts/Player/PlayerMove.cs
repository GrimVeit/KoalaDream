using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform leftBoundary;
    public Transform rightBoundary;

    public float maxSpeed;
    public float accelerationTime = 0.2f;
    public float decelerationTime = 0.2f;

    private float currentSpeed = 0;

    private float targetDirection = 0;

    private void Update()
    {
        float targetSpeed = targetDirection * maxSpeed;

        if(Mathf.Abs(targetSpeed) > Mathf.Abs(currentSpeed))
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, maxSpeed / accelerationTime * Time.deltaTime);
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, maxSpeed / decelerationTime * Time.deltaTime);
        }

        Vector3 pos = transform.position;

        float minX = leftBoundary.position.x;
        float maxX = rightBoundary.position.x;

        pos.x += currentSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        if((pos.x == minX  && currentSpeed < 0) || (pos.x == maxX && currentSpeed > 0))
        {
            currentSpeed = 0f;
        } 

        transform.position = pos;

        OnPositionChanged?.Invoke(pos.x);
    }

    public void Move(float direction)
    {
        targetDirection = Mathf.Clamp(direction, -1, 1);
    }

    #region Output

    public event Action<float> OnPositionChanged;

    #endregion
}
