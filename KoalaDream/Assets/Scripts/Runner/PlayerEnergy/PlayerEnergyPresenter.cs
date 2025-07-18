using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyPresenter : IPlayerEnergyProvider
{
    private readonly PlayerEnergyModel _model;
    private readonly PlayerEnergyView _view;

    public PlayerEnergyPresenter(PlayerEnergyModel model, PlayerEnergyView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _model.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _model.Dispose();
    }

    private void ActivateEvents()
    {
        _model.OnEnergyChanged += _view.SetEnergyValue;
    }

    private void DeactivateEvents()
    {
        _model.OnEnergyChanged -= _view.SetEnergyValue;
    }

    #region Input

    public void AddEnergy(float energy)
    {
        _model.AddEnergy(energy);
    }

    #endregion
}

public interface IPlayerEnergyProvider
{
    void AddEnergy(float size);
}
