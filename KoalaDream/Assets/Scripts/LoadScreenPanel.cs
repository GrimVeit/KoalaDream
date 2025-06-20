using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenPanel : MovePanel
{
    [SerializeField] private LazyMotionGroup lazyMotionGroup;
    [SerializeField] private List<AnimationFrame> frames = new List<AnimationFrame>();

    private void Awake()
    {
        OnDeactivatePanel += lazyMotionGroup.Deactivate;
        OnDeactivatePanel += DeactivateFramesAnimations;

        Initialize();
    }

    private void OnDestroy()
    {
        OnDeactivatePanel -= lazyMotionGroup.Deactivate;
        OnDeactivatePanel -= DeactivateFramesAnimations;

        Dispose();
    }

    public override void Initialize()
    {
        base.Initialize();

        lazyMotionGroup.Initialize();
    }

    public override void Dispose()
    {
        base.Dispose();

        lazyMotionGroup.Dispose();
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        lazyMotionGroup.Activate();
        ActivateFramesAnimations();
    }

    private void ActivateFramesAnimations()
    {
        frames.ForEach(data => data.Activate(-1));
    }

    private void DeactivateFramesAnimations()
    {
        frames.ForEach(data => data.Deactivate());
    }
}
