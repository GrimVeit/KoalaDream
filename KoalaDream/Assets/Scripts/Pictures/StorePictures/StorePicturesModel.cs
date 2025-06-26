using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StorePicturesModel
{
    public event Action<int> OnOpenPicture;
    public event Action<int> OnClosePicture;
    public event Action<int> OnSelectPicture;

    private List<PictureData> pictureDatas = new();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Pictures.json");

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
            if (pictureDatas[i].IsOpen)
            {
                OnOpenPicture?.Invoke(i);
            }
            else
            {
                OnClosePicture?.Invoke(i);
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
        var picture = pictureDatas[id];

        if (picture == null)
        {
            Debug.LogError("Not found picture with id - " + id);
            return;
        }

        if (picture.IsOpen) return;

        picture.IsOpen = true;
        Debug.Log(id);
        OnOpenPicture?.Invoke(id);
    }

    public void SelectPicture(int id)
    {
        var picture = pictureDatas[id];

        if (picture == null)
        {
            Debug.LogError("Not found picture with id - " + id);
            return;
        }

        pictureDatas.ForEach(data => data.IsSelect = false);
        picture.IsSelect = true;
        Debug.Log(id);
        OnSelectPicture?.Invoke(id);
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
