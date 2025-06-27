using System;
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

    public void Initialize()
    {
        buttonPicture.onClick.AddListener(() => OnSelectPicture?.Invoke(id));
    }

    public void Dispose()
    {
        buttonPicture.onClick.RemoveListener(() => OnSelectPicture?.Invoke(id));
    }

    public void Activate()
    {
        imagePicture.color = colorActive;
        objectMarker.SetActive(false);
    }

    public void Deactivate()
    {
        imagePicture.color = colorInactive;
        objectMarker.SetActive(true);
    }

    #region Output

    public event Action<int> OnSelectPicture;

    #endregion
}
