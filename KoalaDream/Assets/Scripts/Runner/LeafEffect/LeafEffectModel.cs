using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class LeafEffectModel
{
    public event Action OnActivateLeaf;
    public event Action OnDeactivateLeaf;

    private IEnumerator coroutineLeaf;

    private readonly float minInterval = 25;
    private readonly float maxInterval = 30;

    private bool isActive = false;

    public void ActivateLeafTimer()
    {
        isActive = true;

        if (coroutineLeaf != null) Coroutines.Stop(coroutineLeaf);

        coroutineLeaf = CoroutineSpawn();
        Coroutines.Start(coroutineLeaf);
    }

    public void DeactivateLeafTimer()
    {
        isActive = false;

        if (coroutineLeaf != null) Coroutines.Stop(coroutineLeaf);

        OnDeactivateLeaf?.Invoke();
    }

    private IEnumerator CoroutineSpawn()
    {
        yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));

        while (isActive)
        {
            OnActivateLeaf?.Invoke();

            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
        }
    }
}
