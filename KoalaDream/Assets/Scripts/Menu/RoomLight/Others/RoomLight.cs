using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RoomLight : MonoBehaviour
{
    public int RoomId => roomId;

    [SerializeField] private int roomId;
    [SerializeField] private List<SpriteRenderer> renderers = new List<SpriteRenderer>();

    public void Activate(float duration)
    {
        renderers.ForEach(data => data.DOFade(0, duration));
    }

    public void Deactivate(float duration)
    {
        renderers.ForEach(data => data.DOFade(1, duration));
    }
}
