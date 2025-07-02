using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationView : View
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private int _currentState;

    public void SetState(int state)
    {
        _currentState = state;

        if (_currentState != 0)
            spriteRenderer.flipX = _currentState < 0;

        playerAnimator.SetBool("isWalking", _currentState != 0);
    }

    public void RotateLeft()
    {
        if (_currentState == 0) 
            spriteRenderer.flipX = true;
    }

    public void RotateRight()
    {
        if (_currentState == 0)
            spriteRenderer.flipX = false;
    }
}
