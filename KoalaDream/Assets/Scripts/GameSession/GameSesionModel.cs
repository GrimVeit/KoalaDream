using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSesionModel
{
    private readonly string KEY;

    private int _gameGlobalState;

    public GameSesionModel(string kEY)
    {
        KEY = kEY;
    }

    public void Initialize()
    {
        _gameGlobalState = PlayerPrefs.GetInt(KEY, 0);
    }

    public void Dispose()
    {
        PlayerPrefs.SetInt(KEY, _gameGlobalState);
    }

    public void SetGame(int id)
    {
        _gameGlobalState = id;
    }

    public void Reset()
    {
        _gameGlobalState = 0;

        PlayerPrefs.DeleteKey(KEY);
    }

    public int GetGameState()
    {
        return _gameGlobalState;
    }
}
