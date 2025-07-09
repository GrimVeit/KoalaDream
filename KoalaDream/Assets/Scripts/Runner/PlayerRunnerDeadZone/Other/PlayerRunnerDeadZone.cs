using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunnerDeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            OnActivateDeadZone?.Invoke();
        }
    }

    #region Output

    public event Action OnActivateDeadZone;

    #endregion
}
