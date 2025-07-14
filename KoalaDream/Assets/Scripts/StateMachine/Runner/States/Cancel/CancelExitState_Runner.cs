using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelExitState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private readonly IPlayerRunnerMoveAutoProvider _playerRunnerMoveAutoProvider;
    private readonly IPlayerRunnerAnimationProvider _playerRunnerAnimationProvider;
    private readonly IRunnerExitProvider _runnerExitProvider;
    private readonly IRunnerGameResultProvider _gameResultProvider;
    private readonly IRunnerResultMoneyInfoProvider _moneyInfoProvider;
    private readonly ISoundProvider _soundProvider;

    private IEnumerator timer;

    public CancelExitState_Runner(IGlobalStateMachineProvider machineProvider, IPlayerRunnerMoveAutoProvider playerRunnerMoveAutoProvider, IPlayerRunnerAnimationProvider playerRunnerAnimationProvider, IRunnerExitProvider runnerExitProvider, IRunnerGameResultProvider gameResultProvider, IRunnerResultMoneyInfoProvider moneyInfoProvider, ISoundProvider soundProvider)
    {
        _machineProvider = machineProvider;
        _playerRunnerMoveAutoProvider = playerRunnerMoveAutoProvider;
        _playerRunnerAnimationProvider = playerRunnerAnimationProvider;
        _runnerExitProvider = runnerExitProvider;
        _gameResultProvider = gameResultProvider;
        _moneyInfoProvider = moneyInfoProvider;
        _soundProvider = soundProvider;
    }

    public void EnterState()
    {
        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(1f);
        Coroutines.Start(timer);

        _playerRunnerMoveAutoProvider.MoveToLoseExitPosition();
        _playerRunnerAnimationProvider.AnimationDown();
        _soundProvider.PlayOneShot("PlayerDown_Big");

        if (_moneyInfoProvider.GetMoney() > 0)
        {
            _gameResultProvider.SetResult(RunnerResult.CancelWithMoney);
        }
        else
        {
            _gameResultProvider.SetResult(RunnerResult.CancelNoMoney);
        }
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);

        _runnerExitProvider.Exit();
    }
}
