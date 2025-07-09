using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRunnerAnimationView : View
{
    [SerializeField] private Image imagePlayer;
    [SerializeField] private Sprite spriteDown_1;
    [SerializeField] private Sprite spriteDown_2;

    private IEnumerator coro;

    public void Down()
    {
        if(coro != null) Coroutines.Stop(coro);

        coro = DownCoro();
        Coroutines.Start(coro);
    }

    private IEnumerator DownCoro()
    {
        imagePlayer.sprite = spriteDown_1;

        yield return new WaitForSeconds(0.2f);

        imagePlayer.sprite = spriteDown_2;
    }
}
