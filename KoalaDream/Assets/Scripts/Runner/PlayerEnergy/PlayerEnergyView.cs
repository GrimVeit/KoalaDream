using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyView : View
{
    [SerializeField] private List<Image> hpElements = new();
    [SerializeField] private Sprite spriteYellow;
    [SerializeField] private Sprite spriteGrey;

    public void SetEnergyValue(float value)
    {
        int number = Mathf.CeilToInt((value / 30) * hpElements.Count);

        if (number > hpElements.Count) return;

        for (int i = 0; i < hpElements.Count; i++)
        {
            hpElements[i].sprite = i < number ? spriteYellow : spriteGrey;
        }
    }
}
