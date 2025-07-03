using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundRandomView : View
{
    [SerializeField] private List<Sprite> spritesBackgrounds = new List<Sprite>();
    [SerializeField] private RawImage imageBackground;

    public void RandomBackground()
    {
        imageBackground.texture = spritesBackgrounds[Random.Range(0, spritesBackgrounds.Count)].texture;
    }
}
