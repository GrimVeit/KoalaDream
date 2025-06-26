using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationView : View
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void SetState(int state)
    {
        if (state != 0)
            spriteRenderer.flipX = state < 0;

        playerAnimator.SetBool("isWalking", state != 0);
    }
}
