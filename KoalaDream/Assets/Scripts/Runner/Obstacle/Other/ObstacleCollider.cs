using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            OnActivate?.Invoke();
        }
    }

    #region Output

    public event Action OnActivate;

    #endregion
}
