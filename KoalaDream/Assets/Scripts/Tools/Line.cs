using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private bool isVisible = true;
    [SerializeField] private Transform point_1;
    [SerializeField] private Transform point_2;
    [SerializeField] private Color color;


    private void OnDrawGizmos()
    {
        if (point_1 != null && point_2 != null)
        {
            if (isVisible)
            {
                Gizmos.color = color;
                Gizmos.DrawLine(point_1.position, point_2.position);
            }
        }
    }
}
