using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerResultMoneyModel
{
    private readonly string KEY;

    private int _currentMoney;

    public RunnerResultMoneyModel(string kEY)
    {
        KEY = kEY;
    }

    public void Initialize()
    {
        _currentMoney = PlayerPrefs.GetInt(KEY, 0);
        OnChangeCountMoney?.Invoke(_currentMoney);
    }

    public void Dispose()
    {
        PlayerPrefs.SetInt(KEY, _currentMoney);
    }

    public void AddMoney(int count)
    {
        _currentMoney += count;
        OnChangeCountMoney?.Invoke(_currentMoney);
    }

    public void Reset()
    {
        _currentMoney = 0;
        OnChangeCountMoney?.Invoke(_currentMoney);

        PlayerPrefs.DeleteKey(KEY);
    }

    public int GetMoney()
    {
        return _currentMoney;
    }

    #region Output

    public event Action<int> OnChangeCountMoney;

    #endregion
}
