using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLoseState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private UIGameSceneRoot_Runner _sceneRoot;

    private readonly IBackgroundScrollProvider _backgroundScrollProvider;
    private readonly IObstacleSpawnerProvider _obstacleSpawnerProvider;
    private readonly ILeafEffectProvider _leafEffectProvider;

    private readonly IPlayerRunnerMoveFreezeProvider _playerRunnerMoveFreezeProvider;

    private readonly ISoundProvider _soundProvider;
    private readonly ISound _soundBackground;

    private IEnumerator timer;

    public ShowLoseState_Runner(IGlobalStateMachineProvider machineProvider, UIGameSceneRoot_Runner sceneRoot, IBackgroundScrollProvider backgroundScrollProvider, IObstacleSpawnerProvider obstacleSpawnerProvider, ILeafEffectProvider leafEffectProvider, IPlayerRunnerMoveFreezeProvider playerRunnerMoveFreezeProvider, ISoundProvider soundProvider)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _backgroundScrollProvider = backgroundScrollProvider;
        _obstacleSpawnerProvider = obstacleSpawnerProvider;
        _leafEffectProvider = leafEffectProvider;
        _playerRunnerMoveFreezeProvider = playerRunnerMoveFreezeProvider;
        _soundProvider = soundProvider;

        _soundBackground = _soundProvider.GetSound("Background");
    }

    public void EnterState()
    {
        _sceneRoot.CloseBalancePanel();
        _sceneRoot.CloseEnergyPanel();

        _backgroundScrollProvider.DeactivateScroll();
        _obstacleSpawnerProvider.DeactivateSpawner();
        _leafEffectProvider.DeactivateLeafTimer();

        _playerRunnerMoveFreezeProvider.Freeze();
        _sceneRoot.OpenLosePanel();

        if(timer != null) Coroutines.Stop(timer);

        timer = Timer(3f);
        Coroutines.Start(timer);

        _soundBackground.SetVolume(0.6f, 0.2f, 0.2f);
        _soundProvider.PlayOneShot("Lose");
    }

    public void ExitState()
    {
        _sceneRoot.CloseLosePanel();

        if (timer != null) Coroutines.Stop(timer);

        _soundBackground.SetVolume(0.2f, 0.6f, 0.2f);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        ChangeStateToLoseExit();
    }

    private void ChangeStateToLoseExit()
    {
        _machineProvider.SetState(_machineProvider.GetState<LoseExitState_Runner>());
    }
}
