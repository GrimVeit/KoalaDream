using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StorePicturesModel
{
    public event Action<Picture> OnOpenPicture;
    public event Action<Picture> OnClosePicture;


    public event Action<Picture> OnSelectPicture;
    public event Action<Picture> OnSelectOpenPicture_Value;
    public event Action<Picture> OnSelectClosePicture_Value;
    public event Action OnSelectOpenPicture;
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
                pictureDatas.Add(new PictureData(false, false));
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

    public void OpenPicture(int id)
    {
        var picture = _pictureGroup.GetPicture(id);

        if (picture == null)
        {
            Debug.LogError("Not found picture with id - " + id);
            return;
        }

        if (picture.PictureData.IsOpen) return;

        picture.PictureData.IsOpen = true;
        Debug.Log(id);
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
        Debug.Log(id);

        if (picture.PictureData.IsOpen)
        {
            OnSelectOpenPicture_Value?.Invoke(picture);
            OnSelectOpenPicture?.Invoke();
        }
        else
        {
            OnSelectClosePicture_Value?.Invoke(picture);
            OnSelectClosePicture?.Invoke();
        }

        OnSelectPicture?.Invoke(picture);
    }

    public void DeselectAll()
    {

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
    public bool IsSelect;

    public PictureData(bool isOpen, bool isSelect)
    {
        IsOpen = isOpen;
        IsSelect = isSelect;
    }
}
