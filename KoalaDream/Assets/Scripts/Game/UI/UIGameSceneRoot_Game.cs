using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameSceneRoot_Game : UIRoot
{
    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        this._soundProvider = soundProvider;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    public void Activate()
    {

    }

    public void Deactivate()
    {


        if (currentPanel != null)
            CloseOtherPanel(currentPanel);
    }
}
