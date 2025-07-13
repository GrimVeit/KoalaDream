using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSoundModel
{
    private readonly ISoundProvider _soundProvider;

    public PlayerAnimationSoundModel(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void ActivateSound(string id)
    {
        _soundProvider.PlayOneShot(id);
    }
}
