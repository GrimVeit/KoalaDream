using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PicturesShowVisualView : View
{
    [SerializeField] private Image imagePicture;
    [SerializeField] private TextMeshProUGUI textNumberPicture;

    public void ShowPicture(Picture picture)
    {
        textNumberPicture.text = "#" + (picture.Id + 1);
        imagePicture.sprite = picture.SpritePictureFull;
    }
}
