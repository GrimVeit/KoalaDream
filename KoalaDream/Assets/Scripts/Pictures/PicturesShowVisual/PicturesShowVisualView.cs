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
    [SerializeField] private List<ShowPicture> showPictureList = new List<ShowPicture>();

    public void ShowPicture(int index)
    {
        textNumberPicture.text = "#" + (index + 1);
        imagePicture.sprite = GetSprite(index);
    }

    private Sprite GetSprite(int id)
    {
        return showPictureList.FirstOrDefault(data => data.Id == id).SpritePicture;
    }
}

[Serializable]
public class ShowPicture
{
    [SerializeField] private int id;
    [SerializeField] private Sprite spritePicture;

    public int Id => id;
    public Sprite SpritePicture => spritePicture;
}
