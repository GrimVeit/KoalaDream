using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StorePicturesModel
{
    public event Action<Picture> OnOpenPicture;
    public event Action<Picture> OnClosePicture;
    public event Action<Picture> OnPreviewPicture;


    public event Action<Picture> OnSelectPicture;

    public event Action<Picture> OnSelectOpenPicture_Value;
    public event Action<Picture> OnSelectPreviewPicture_Value;
    public event Action<Picture> OnSelectClosePicture_Value;

    public event Action OnSelectOpenPicture;
    public event Action OnSelectPreviewPicture;
    public event Action OnSelectClosePicture;

    private PictureGroup _pictureGroup;

    private List<PictureData> pictureDatas = new();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Pictures.json");

    public StorePicturesModel(PictureGroup pictureGroup)
    {
        _pictureGroup = pictureGroup;
    }

    public void Initialize()
    {
        if (File.Exists(FilePath))
        {
            string loadedJson = File.ReadAllText(FilePath);
            PictureDatas pictureDatas = JsonUtility.FromJson<PictureDatas>(loadedJson);

            this.pictureDatas = pictureDatas.Datas.ToList();
        }
        else
        {
            pictureDatas = new List<PictureData>();

            for (int i = 0; i < 12; i++)
            {
                pictureDatas.Add(new PictureData(false, false, false));
            }
        }

        for (int i = 0; i < pictureDatas.Count; i++)
        {
            _pictureGroup.Pictures[i].SetData(pictureDatas[i]);

            if (_pictureGroup.Pictures[i].PictureData.IsOpen)
            {
                OnOpenPicture?.Invoke(_pictureGroup.Pictures[i]);
            }
            else
            {
                OnClosePicture?.Invoke(_pictureGroup.Pictures[i]);
            }

            if (_pictureGroup.Pictures[i].PictureData.IsPreview)
            {
                OnPreviewPicture?.Invoke(_pictureGroup.Pictures[i]);
            }

            if (_pictureGroup.Pictures[i].PictureData.IsSelect)
            {
                if (_pictureGroup.Pictures[i].PictureData.IsOpen)
                {
                    OnSelectOpenPicture_Value?.Invoke(_pictureGroup.Pictures[i]);
                    OnSelectOpenPicture?.Invoke();
                }
                else
                {
                    OnSelectClosePicture_Value?.Invoke(_pictureGroup.Pictures[i]);
                    OnSelectClosePicture?.Invoke();
                }

                OnSelectPicture?.Invoke(_pictureGroup.Pictures[i]);
            }
        }
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(new PictureDatas(pictureDatas.ToArray()));
        File.WriteAllText(FilePath, json);
    }

    public void PreviewPicture(int id)
    {
        var picture = _pictureGroup.GetPicture(id);

        if (picture == null)
        {
            Debug.LogError("Not found picture with id - " + id);
            return;
        }

        picture.PictureData.IsOpen = false;
        picture.PictureData.IsPreview = true;

        OnPreviewPicture?.Invoke(picture);
    }

    public void OpenPicture(int id)
    {
        var picture = _pictureGroup.GetPicture(id);

        if (picture == null)
        {
            Debug.LogError("Not found picture with id - " + id);
            return;
        }

        picture.PictureData.IsPreview = false;
        picture.PictureData.IsOpen = true;

        OnOpenPicture?.Invoke(picture);
    }

    public void SelectPicture(int id)
    {
        var picture = _pictureGroup.GetPicture(id);

        if (picture == null)
        {
            Debug.LogError("Not found picture with id - " + id);
            return;
        }

        pictureDatas.ForEach(data => data.IsSelect = false);
        picture.PictureData.IsSelect = true;

        if (picture.PictureData.IsOpen)
        {
            OnSelectOpenPicture_Value?.Invoke(picture);
            OnSelectOpenPicture?.Invoke();
        }
        else if (picture.PictureData.IsPreview)
        {
            OnSelectPreviewPicture_Value?.Invoke(picture);
            OnSelectPreviewPicture?.Invoke();
        }
        else
        {
            OnSelectClosePicture_Value?.Invoke(picture);
            OnSelectClosePicture?.Invoke();
        }

        OnSelectPicture?.Invoke(picture);
    }

    public bool IsHavePrevious()
    {
        return pictureDatas.Any(p => p.IsPreview = true);
    }
}

[Serializable]
public class PictureDatas
{
    public PictureData[] Datas;

    public PictureDatas(PictureData[] datas)
    {
        Datas = datas;
    }
}

[Serializable]
public class PictureData
{
    public bool IsOpen;
    public bool IsPreview;
    public bool IsSelect;

    public PictureData(bool isOpen, bool isPreviewed, bool isSelect)
    {
        IsOpen = isOpen;
        IsPreview = isPreviewed;
        IsSelect = isSelect;
    }
}
