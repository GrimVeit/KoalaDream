using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePuzzleAccessModel
{
    private IMoneyProvider _moneyProvider;
    private IStorePicturesSelectEventsProvider _storePicturesSelectEventsProvider;

    private Picture _currentPicture;

    public PicturePuzzleAccessModel(IMoneyProvider moneyProvider, IStorePicturesSelectEventsProvider storePicturesSelectEventsProvider)
    {
        _moneyProvider = moneyProvider;
        _storePicturesSelectEventsProvider = storePicturesSelectEventsProvider;

        _storePicturesSelectEventsProvider.OnSelectClosePicture_Value += SelectClosePicture;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _storePicturesSelectEventsProvider.OnSelectClosePicture_Value -= SelectClosePicture;
    }

    public void ActivatePuzzle()
    {
        //_moneyProvider.SendMoney(-_currentPicture.Price);

        OnActivatePuzzle?.Invoke();
    }

    private void SelectClosePicture(Picture picture)
    {
        _currentPicture = picture;

        if (!_moneyProvider.CanAfford(_currentPicture.Price))
        {
            int needCost = _currentPicture.Price - _moneyProvider.GetMoney();

            OnCloseAccess?.Invoke(needCost);
        }
        else
        {
            OnOpenAccess?.Invoke();
        }
    }

    #region Output

    public event Action<int> OnCloseAccess;
    public event Action OnOpenAccess;

    public event Action OnActivatePuzzle;

    #endregion
}
