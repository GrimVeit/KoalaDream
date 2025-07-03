using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionPresenter : IGameSessionProvider, IGameSessionInfoProvider
{
    private readonly GameSesionModel _model;

    public GameSessionPresenter(GameSesionModel model)
    {
        _model = model;
    }

    public void Initialize()
    {
        _model.Initialize();
    }

    public void Dispose()
    {
        _model.Dispose();
    }

    #region Input

    public void SetGame(int index)
    {
        _model.SetGame(index);
    }

    public void Reset()
    {
        _model.Reset();
    }

    public int GetGameState()
    {
        return _model.GetGameState();
    }

    #endregion
}

public interface IGameSessionProvider
{
    void SetGame(int index);
}

public interface IGameSessionInfoProvider
{
    public int GetGameState();
}
