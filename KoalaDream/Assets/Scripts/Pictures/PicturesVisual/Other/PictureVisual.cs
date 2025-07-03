using System;
using DG.Tweening;
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
    [SerializeField] private ParticleSystem particle;

    public void Initialize()
    {
        buttonPicture.onClick.AddListener(() => OnSelectPicture?.Invoke(id));
    }

    public void Dispose()
    {
        buttonPicture.onClick.RemoveListener(() => OnSelectPicture?.Invoke(id));
    }

    public void Open()
    {
        if(particle.isPlaying) particle.Stop();

        imagePicture.color = colorActive;
        imagePicture.transform.localScale = Vector3.zero;
        imagePicture.transform.DOScale(1, 0.2f);
        objectMarker.SetActive(false);
    }

    public void Close()
    {
        if (particle.isPlaying) particle.Stop();

        imagePicture.color = colorInactive;
        objectMarker.SetActive(true);
    }

    public void Preview()
    {
        imagePicture.color = colorInactive;
        particle.Play();

        objectMarker.SetActive(false);
    }

    #region Output

    public event Action<int> OnSelectPicture;

    #endregion
}
