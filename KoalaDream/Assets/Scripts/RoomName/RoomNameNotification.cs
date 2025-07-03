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

    private IEnumerator timerWait;
    private IEnumerator timerTypeText;

    private Sequence sequence;

    private string _roomName;
    private float _durationTextTyping;

    public void SetData(string roomName, float durationTextTyping, Transform transformEnd)
    {
        _roomName = roomName;
        _durationTextTyping = durationTextTyping;

        _transformEnd = transformEnd;
    }

    public void Activate(Transform transformDown)
    {
        sequence?.Kill();

        sequence = DOTween.Sequence();


        sequence
            .Append(transform.DOLocalMove(transformDown.localPosition, durationMove).SetEase(Ease.InOutBounce, 0.1f))
            .Join(textName.DOFade(1, durationMove));

        if(timerWait != null) Coroutines.Stop(timerWait);
        if(timerTypeText != null) Coroutines.Stop(timerTypeText);

        timerWait = Timer();
        Coroutines.Start(timerWait);

        timerTypeText = AddText();
        Coroutines.Start(timerTypeText);
    }

    public void Deactivate()
    {
        if (timerWait != null) Coroutines.Stop(timerWait);

        sequence?.Kill();

        sequence = DOTween.Sequence();

        sequence.Append(textName.DOFade(0, durationMove))
            .Join(transform.DOLocalMove(_transformEnd.localPosition, durationMove))
            .OnComplete(() => Destroy(gameObject));
    }

    private void OnDestroy()
    {
        if (timerWait != null) Coroutines.Stop(timerWait);
        if (timerTypeText != null) Coroutines.Stop(timerTypeText);

        sequence?.Kill();
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(durationWaitTime);

        Deactivate();
    }

    private IEnumerator AddText()
    {
        textName.text = "";

        foreach(char c in _roomName)
        {
            textName.text += c;

            yield return new WaitForSeconds(_durationTextTyping);
        }

        yield return new WaitForSeconds(0.7f);

        textName.text = _roomName;

        for (int i = _roomName.Length - 1; i >= 0; i--)
        {
            textName.text = textName.text.Substring(0, i);
            yield return new WaitForSeconds(_durationTextTyping);
        }
    }

    //private IEnumerator RemoveText()
    //{
    //    textName.text = _roomName;

    //    for (int i = _roomName.Length - 1; i >= 0; i--)
    //    {
    //        textName.text = textName.text.Substring(0, i);
    //        yield return new WaitForSeconds(_durationTextTyping);
    //    }
    //}
}
