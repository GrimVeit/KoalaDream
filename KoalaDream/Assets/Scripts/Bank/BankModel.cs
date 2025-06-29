using System;
using UnityEngine;

public class BankModel
{
    public int Money => _money;

    private int _money;
    public event Action OnAddMoney;
    public event Action OnRemoveMoney;
    public event Action<int> OnChangeMoney;

    private const string BANK_MONEY = "BANK_MONEY";

    public void Initialize()
    {
        _money = PlayerPrefs.GetInt(BANK_MONEY, 24);
    }

    public void Destroy()
    {
        PlayerPrefs.SetFloat(BANK_MONEY, _money);
    }

    public void SendMoney(int money)
    {
        Debug.Log(money);

        if(money >= 0)
        {
            OnAddMoney?.Invoke();
        }
        else
        {
            OnRemoveMoney?.Invoke();
        }

        _money += money;

        if(_money < 0)
        {
            _money = 0;
        }

        OnChangeMoney?.Invoke(_money);

        Debug.Log(_money);
    }

    public bool CanAfford(int bet)
    {
        return _money >= bet;
    }
}
