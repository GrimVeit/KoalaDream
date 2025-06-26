using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PicturesVisualView : View
{
    [SerializeField] private List<PictureVisual> pictureVisuals = new List<PictureVisual>();

    public void Open(int index)
    {
        var visual = GetPictureVisual(index);

        if(visual == null)
        {
            Debug.LogWarning("Not found picture visual with id - " + index);
            return;
        }

        visual.Activate();
    }

    public void Close(int index)
    {
        var visual = GetPictureVisual(index);

        if (visual == null)
        {
            Debug.LogWarning("Not found picture visual with id - " + index);
            return;
        }

        visual.Deactivate();
    }

    private PictureVisual GetPictureVisual(int id)
    {
        return pictureVisuals.FirstOrDefault(data => data.Id == id);
    }
}
