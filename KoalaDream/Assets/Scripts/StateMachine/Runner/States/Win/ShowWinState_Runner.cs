using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWinState_Runner : MonoBehaviour
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private IEnumerator timer;

    public ShowWinState_Runner(IGlobalStateMachineProvider machineProvider)
    {
        _machineProvider = machineProvider;
    }

    public void EnterState()
    {
        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(0.3f);
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        ChangeStateToShowWin();
    }

    private void ChangeStateToShowWin()
    {

    }
}
