using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunnerResultMoneyVisualView : View
{
    [SerializeField] private List<TextMeshProUGUI> textsMoney = new();
    public void SetMoney(int money)
    {
        textsMoney.ForEach(data => data.text = $"puzzle collected: {money}");
    }
}
