using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Picture", menuName = "Game/Picture/New")]
public class Picture : ScriptableObject
{
    public int Id => id;
    public int Price => price;
    public Sprite SpritePictureFull => spritePictureFull;
    public PictureData PictureData => _pictureData;

    [SerializeField] private int id;
    [SerializeField] private int price;
    [SerializeField] private Sprite spritePictureFull;
    private PictureData _pictureData;

    public void SetData(PictureData data)
    {
        _pictureData = data;
    }
}
