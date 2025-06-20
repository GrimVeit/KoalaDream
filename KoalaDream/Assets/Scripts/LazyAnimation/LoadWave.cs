using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadWave : MotionBase
{
    [SerializeField] private List<Image> blocks = new List<Image>();
    [SerializeField] private Sprite spriteGray;
    [SerializeField] private Sprite spriteYellow;

    [SerializeField] private float stepDelay;
    [SerializeField] private int waveLength;
    [SerializeField] private float cycles;

    private IEnumerator waveIEnumerator;

    public override void Activate()
    {
        blocks.ForEach(data => data.sprite = spriteGray);

        if(waveIEnumerator is not null) Coroutines.Stop(waveIEnumerator);

        waveIEnumerator = WaveCoro();
        Coroutines.Start(waveIEnumerator);
    }

    public override void Deactivate()
    {
        if (waveIEnumerator is not null) Coroutines.Stop(waveIEnumerator);
    }

    private IEnumerator WaveCoro()
    {
        while (true)
        {
            for (int i = 0; i < waveLength; i++)
            {
                blocks[i].sprite = spriteYellow;
                yield return new WaitForSeconds(stepDelay);
            }

            int maxStart = blocks.Count - waveLength;

            for (int start = 0; start <= maxStart; start++)
            {
                blocks[start - 1].sprite = spriteGray;
                blocks[start + waveLength - 1].sprite = spriteYellow;
                yield return new WaitForSeconds(stepDelay);
            }

            for (int i = blocks.Count - waveLength; i < blocks.Count; i++)
            {
                blocks[i].sprite = spriteGray;
                yield return new WaitForSeconds(stepDelay);
            }

            yield return new WaitForSeconds(cycles);
        }
    }
}
