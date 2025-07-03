using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class RoomNameNotification : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private float durationWaitTime;
    [SerializeField] private float durationMove;

    private Transform _transformEnd;

    private IEnumerator timer;

    private Sequence sequence;

    public void SetData(string roomName, float durationTextTyping, Transform transformEnd)
    {
        textName.text = roomName;
        _transformEnd = transformEnd;
    }

    public void Activate(Transform transformDown)
    {
        sequence?.Kill();

        sequence = DOTween.Sequence();

        sequence
            .Append(transform.DOLocalMove(transformDown.localPosition, durationMove))
            .Join(textName.DOFade(1, durationMove));

        if(timer != null) Coroutines.Stop(timer);

        timer = Timer();
        Coroutines.Start(timer);
    }

    public void Deactivate()
    {
        if (timer != null) Coroutines.Stop(timer);

        sequence?.Kill();

        sequence = DOTween.Sequence();

        sequence.Append(textName.DOFade(0, durationMove))
            .Join(transform.DOLocalMove(_transformEnd.localPosition, durationMove))
            .OnComplete(() => Destroy(gameObject));
    }

    private void OnDestroy()
    {
        sequence?.Kill();
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(durationWaitTime);

        Deactivate();
    }
}
