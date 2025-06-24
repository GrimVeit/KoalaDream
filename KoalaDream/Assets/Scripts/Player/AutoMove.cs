using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    [SerializeField] private List<Transform> tests = new List<Transform>();

    [SerializeField] private PlayerMove playerMove;

    [SerializeField] private bool isActive = false;
    [SerializeField] private float stopTreshold = 0.05f;

    private Transform currentTarget;

    private void Awake()
    {
        //playerMove.OnPositionChanged += OnPositionChanged;
    }

    private void OnDestroy()
    {
        //playerMove.OnPositionChanged -= OnPositionChanged;
    }

    public void MoveTo(Transform target)
    {
        //currentTarget = target;
        //isActive = true;
        //UpdateDirection();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha0))
    //    {
    //        MoveTo(tests[0]);
    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        MoveTo(tests[1]);
    //    }
    //}

    private void OnPositionChanged(float currentX)
    {
        if(!isActive) return;

        if(currentTarget == null) return;

        float diff = currentTarget.position.x - currentX;

        if(Mathf.Abs(diff) < stopTreshold)
        {
            Cancel();
        }
    }

    private void UpdateDirection()
    {
        if(currentTarget == null)
        {
            Cancel();
            return;
        }

        float diff = currentTarget.position.x - playerMove.transform.position.x;

        if(Mathf.Abs(diff) < stopTreshold)
        {
            Cancel();
            return;
        }

        playerMove.Move(Mathf.Sign(diff));
    }

    private void Cancel()
    {
        isActive = false;
        playerMove.Move(0);
    }
}
