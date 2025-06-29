using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PicturesOpenVisualView : View
{
    [SerializeField] private Image imagePicture;
    [SerializeField] private Image imageBorder;
    [SerializeField] private TextMeshProUGUI textPricePicture;
    [SerializeField] private List<PictureBorder> pictureBorders = new List<PictureBorder>();

    public void OpenPicture(Picture picture)
    {
        imagePicture.sprite = picture.SpritePictureFull;
        textPricePicture.text = $"Unlock cost: {picture.Price}";

        var border = GetPictureBorder(picture.Id);

        imageBorder.sprite = border.SpriteBorder;
        imageBorder.rectTransform.localPosition = border.PositionBorder;
        imageBorder.rectTransform.sizeDelta = border.RectSize;
    }

    private PictureBorder GetPictureBorder(int id)
    {
        return pictureBorders.FirstOrDefault(data => data.Id == id);
    }
}

[Serializable]
public class PictureBorder
{
    [SerializeField] private int id;
    [SerializeField] private Sprite spriteBorder;
    [SerializeField] private Vector2 positionBorder;
    [SerializeField] private Vector2 rectSize;

    public int Id => id;
    public Sprite SpriteBorder => spriteBorder;
    public Vector2 PositionBorder => positionBorder;
    public Vector2 RectSize => rectSize;
}
