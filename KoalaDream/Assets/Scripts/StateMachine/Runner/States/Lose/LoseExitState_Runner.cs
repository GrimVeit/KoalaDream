using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseExitState_Runner : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;

    private readonly IPlayerRunnerMoveAutoProvider _playerRunnerMoveAutoProvider;
    private readonly IPlayerRunnerAnimationProvider _playerRunnerAnimationProvider;
    private readonly IRunnerExitProvider _runnerExitProvider;
    private readonly IRunnerGameResultProvider _gameResultProvider;
    private readonly IRunnerResultMoneyInfoProvider _moneyInfoProvider;

    private IEnumerator timer;

    public LoseExitState_Runner(IGlobalStateMachineProvider machineProvider, IPlayerRunnerMoveAutoProvider playerRunnerMoveAutoProvider, IPlayerRunnerAnimationProvider playerRunnerAnimationProvider, IRunnerExitProvider runnerExitProvider, IRunnerGameResultProvider gameResultProvider, IRunnerResultMoneyInfoProvider moneyInfoProvider)
    {
        _machineProvider = machineProvider;
        _playerRunnerMoveAutoProvider = playerRunnerMoveAutoProvider;
        _playerRunnerAnimationProvider = playerRunnerAnimationProvider;
        _runnerExitProvider = runnerExitProvider;
        _gameResultProvider = gameResultProvider;
        _moneyInfoProvider = moneyInfoProvider;
    }

    public void EnterState()
    {
        if (timer != null) Coroutines.Stop(timer);

        timer = Timer(1f);
        Coroutines.Start(timer);

        _playerRunnerMoveAutoProvider.MoveToLoseExitPosition();
        _playerRunnerAnimationProvider.AnimationDown();

        if(_moneyInfoProvider.GetMoney() > 0)
        {
            _gameResultProvider.SetResult(RunnerResult.LoseWithMoney);
        }
        else
        {
            _gameResultProvider.SetResult(RunnerResult.LoseNoMoney);
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
