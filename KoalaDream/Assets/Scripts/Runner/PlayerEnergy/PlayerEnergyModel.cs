using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyModel
{
    private readonly ITouchSystemEventsProvider _touchSystemEventsProvider;

    private IEnumerator energyCoroutine;

    private float _currentEnergy = 30f;

    public PlayerEnergyModel(ITouchSystemEventsProvider touchSystemEventsProvider)
    {
        _touchSystemEventsProvider = touchSystemEventsProvider;

        _touchSystemEventsProvider.OnStartTouch += Activate;
        _touchSystemEventsProvider.OnStopTouch += Deactivate;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _touchSystemEventsProvider.OnStartTouch -= Activate;
        _touchSystemEventsProvider.OnStopTouch -= Deactivate;
    }

    private void Activate()
    {
        if(energyCoroutine != null) Coroutines.Stop(energyCoroutine);

        energyCoroutine = EnergyCountdown();
        Coroutines.Start(energyCoroutine);
    }

    private void Deactivate()
    {
        if (energyCoroutine != null) Coroutines.Stop(energyCoroutine);
    }

    private IEnumerator EnergyCountdown()
    {
        while(_currentEnergy > 0)
        {
            _currentEnergy -= Time.deltaTime;

            if(_currentEnergy < 0) _currentEnergy = 0;

            //Debug.Log(_currentEnergy.ToString());

            OnEnergyChanged?.Invoke(_currentEnergy);

            if(_currentEnergy == 0)
            {
                OnFinished?.Invoke();
                yield break;
            }

            yield return null;
        }
    }

    public void AddEnergy(float size)
    {
        if(size < 0) return;

        _currentEnergy += size;
    }

    #region Output

    public event Action OnFinished;
    public event Action<float> OnEnergyChanged;

    #endregion
}
