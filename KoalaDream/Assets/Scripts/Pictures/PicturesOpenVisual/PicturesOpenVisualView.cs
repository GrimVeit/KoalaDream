using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PicturesOpenVisualView : View
{
    [SerializeField] private Image imagePicture;
    [SerializeField] private TextMeshProUGUI textPricePicture;

    public void OpenPicture(Picture picture)
    {
        imagePicture.sprite = picture.SpritePictureFull;
        textPricePicture.text = $"Unlock cost: {picture.Price}";
    }
}
