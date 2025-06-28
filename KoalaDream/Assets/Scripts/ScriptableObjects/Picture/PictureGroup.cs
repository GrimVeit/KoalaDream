using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PictureGroup", menuName = "Game/Picture/NewGroup")]
public class PictureGroup : ScriptableObject
{
    public List<Picture> Pictures = new();

    public Picture GetPicture(int id)
    {
        return Pictures.FirstOrDefault(data => data.Id == id);
    }
}
