using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureVisual : MonoBehaviour
{
    public int Id => id;

    [SerializeField] private int id;
    [SerializeField] private Button buttonPicture;
    [SerializeField] private Image imagePicture;
    [SerializeField] private GameObject objectMarker;
    [SerializeField] private Color colorActive;
    [SerializeField] private Color colorInactive;

    public void Activate()
    {
        buttonPicture.enabled = false;
        imagePicture.color = colorActive;
        objectMarker.SetActive(false);
    }

    public void Deactivate()
    {
        buttonPicture.enabled = true;
        imagePicture.color = colorInactive;
        objectMarker.SetActive(true);
    }
}
