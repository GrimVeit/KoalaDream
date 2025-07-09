using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class WinPanel_Runner : MovePanel
{
    [SerializeField] private AnimationFrame animationFrame;

    [SerializeField] private TextMeshProUGUI textCompleted;
    [SerializeField] private float durationTextReveal;

    private Material _material;

    public override void Initialize()
    {
        animationFrame.OnFinish += PlayReveal; 

        _material = textCompleted.fontMaterial;
        _material.SetFloat(ShaderUtilities.ID_FaceDilate, -1);

        base.Initialize();
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        animationFrame.Activate(1);
    }

    public override void Dispose()
    {
        animationFrame.OnFinish -= PlayReveal;

        base.Dispose();
    }

    private void PlayReveal()
    {
        _material.SetFloat(ShaderUtilities.ID_FaceDilate, -1);

        DOTween.To(
            () => _material.GetFloat(ShaderUtilities.ID_FaceDilate), 
            x => _material.SetFloat(ShaderUtilities.ID_FaceDilate, x), 
            0, 
            durationTextReveal
            ).SetEase(Ease.InQuad);
    }
}
