using System;

public class BankPresenter : IMoneyProvider
{
    private readonly BankModel _model;
    private readonly BankView _view;

    public BankPresenter(BankModel model, BankView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        _model.Initialize();
        _view.Initialize();

        _model.OnAddMoney += _view.AddMoney;
        _model.OnRemoveMoney += _view.RemoveMoney;
        _model.OnChangeMoney += _view.SendMoneyDisplay;

        _view.SendMoneyDisplay(_model.Money);
    }

    public void Dispose()
    {
        _model.OnAddMoney -= _view.AddMoney;
        _model.OnRemoveMoney -= _view.RemoveMoney;
        _model.OnChangeMoney -= _view.SendMoneyDisplay;

        _model.Destroy();
    }

    public void SendMoney(int money)
    {
        _model.SendMoney(money);
    }

    public bool CanAfford(int money)
    {
        return _model.CanAfford(money);
    }

    public int GetMoney() => _model.Money;

    public event Action<int> OnChangeMoney
    {
        add { _model.OnChangeMoney += value; }
        remove { _model.OnChangeMoney -= value; }
    }
}

public interface IMoneyProvider
{
    int GetMoney();

    event Action<int> OnChangeMoney;
    void SendMoney(int money);
    bool CanAfford(int money);
}


