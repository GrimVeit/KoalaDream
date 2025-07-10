using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntryPoint_Runner : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private SpawnPointsData spawnPointsData;
    [SerializeField] private UIGameSceneRoot_Runner sceneRootPrefab;

    private UIGameSceneRoot_Runner sceneRoot;
    private ViewContainer viewContainer;
    private BankPresenter bankPresenter;
    private SoundPresenter soundPresenter;
    private ParticleEffectPresenter particleEffectPresenter;

    private BackgroundRandomPresenter backgroundRandomPresenter;
    private GameSessionPresenter gameSessionPresenter;

    private TouchSystemPresenter touchSystemPresenter;
    private PlayerRunnerMovePresenter playerRunnerMovePresenter;
    private PlayerRunnerMoveAutoPresenter playerRunnerMoveAutoPresenter;
    private PlayerRunnerAnimationPresenter playerRunnerAnimationPresenter;
    private PlayerEnergyPresenter playerEnergyPresenter;
    private PlayerRunnerDeadZonePresenter playerRunnerDeadZonePresenter;
    private ScrollBackgroundPresenter scrollBackgroundPresenter;

    private ObstacleSpawnerPresenter obstacleSpawnerPresenter;
    private ObstaclePresenter obstaclePresenter;

    private PlayerPunchPresenter playerPunchPresenter;
    private PlayerAddEnergyPresenter playerAddEnergyPresenter;
    private PlayerAddMoneyPresenter playerAddMoneyPresenter;

    private RunnerExitPresenter runnerExitPresenter;

    private LeafEffectPresenter leafEffectPresenter;

    private RunnerResultMoneyPresenter runnerResultMoneyPresenter;
    private RunnerGameResultPresenter runnerGameResultPresenter;

    private StateRunnerMachine stateRunnerMachine;


    //private void Awake()
    //{
    //    Run(null);
    //}

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = sceneRootPrefab;

        //uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter(new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS), viewContainer.GetView<SoundView>());
        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());
        particleEffectPresenter = new ParticleEffectPresenter(new ParticleEffectModel(), viewContainer.GetView<ParticleEffectView>());

        backgroundRandomPresenter = new BackgroundRandomPresenter(viewContainer.GetView<BackgroundRandomView>());
        gameSessionPresenter = new GameSessionPresenter(new GameSesionModel(PlayerPrefsKeys.GAME_TYPE));

        touchSystemPresenter = new TouchSystemPresenter(new TouchSystemModel(), viewContainer.GetView<TouchSystemView>());
        playerRunnerMovePresenter = new PlayerRunnerMovePresenter(new PlayerRunnerMoveModel(touchSystemPresenter), viewContainer.GetView<PlayerRunnerMoveView>());
        playerRunnerMoveAutoPresenter = new PlayerRunnerMoveAutoPresenter(viewContainer.GetView<PlayerRunnerMoveAutoView>());
        playerRunnerAnimationPresenter = new PlayerRunnerAnimationPresenter(viewContainer.GetView<PlayerRunnerAnimationView>());
        playerEnergyPresenter = new PlayerEnergyPresenter(new PlayerEnergyModel(touchSystemPresenter), viewContainer.GetView<PlayerEnergyView>());
        playerRunnerDeadZonePresenter = new PlayerRunnerDeadZonePresenter(new PlayerRunnerDeadZoneModel(), viewContainer.GetView<PlayerRunnerDeadZoneView>());
        scrollBackgroundPresenter = new ScrollBackgroundPresenter(new ScrollBackgroundModel(), viewContainer.GetView<ScrollBackgroundView>());

        obstacleSpawnerPresenter = new ObstacleSpawnerPresenter(new ObstacleSpawnerModel(spawnPointsData, 2, 5), viewContainer.GetView<ObstacleSpawnerView>());
        obstaclePresenter = new ObstaclePresenter(new ObstacleModel(obstacleSpawnerPresenter), viewContainer.GetView<ObstacleView>());

        runnerResultMoneyPresenter = new RunnerResultMoneyPresenter(new RunnerResultMoneyModel(PlayerPrefsKeys.RUNNER_RESULT_MONEY));
        playerPunchPresenter = new PlayerPunchPresenter(new PlayerPunchModel(obstacleSpawnerPresenter, playerRunnerMovePresenter));
        playerAddEnergyPresenter = new PlayerAddEnergyPresenter(new PlayerAddEnergyModel(obstacleSpawnerPresenter, playerEnergyPresenter));
        playerAddMoneyPresenter = new PlayerAddMoneyPresenter(new PlayerAddMoneyModel(obstacleSpawnerPresenter, bankPresenter, runnerResultMoneyPresenter));

        runnerExitPresenter = new RunnerExitPresenter(new RunnerExitModel());

        leafEffectPresenter = new LeafEffectPresenter(new LeafEffectModel(), viewContainer.GetView<LeafEffectView>());

        runnerGameResultPresenter = new RunnerGameResultPresenter(new RunnerGameResultModel(PlayerPrefsKeys.RUNNER_RESULT));

        stateRunnerMachine = new StateRunnerMachine(
            sceneRoot,
            backgroundRandomPresenter,
            scrollBackgroundPresenter,
            obstacleSpawnerPresenter,
            leafEffectPresenter,
            playerAddMoneyPresenter,
            playerRunnerMovePresenter,
            playerRunnerMoveAutoPresenter,
            playerRunnerMoveAutoPresenter,
            playerRunnerDeadZonePresenter,
            playerRunnerAnimationPresenter,
            runnerExitPresenter,
            runnerGameResultPresenter,
            runnerResultMoneyPresenter);
        
        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Activate();

        ActivateEvents();

        sceneRoot.Initialize();

        bankPresenter.Initialize();
        soundPresenter.Initialize();
        particleEffectPresenter.Initialize();

        gameSessionPresenter.Initialize();
        backgroundRandomPresenter.Initialize();

        scrollBackgroundPresenter.Initialize();
        playerRunnerDeadZonePresenter.Initialize();
        playerEnergyPresenter.Initialize();
        playerRunnerAnimationPresenter.Initialize();
        playerRunnerMoveAutoPresenter.Initialize();
        playerRunnerMovePresenter.Initialize();
        touchSystemPresenter.Initialize();

        playerAddMoneyPresenter.Initialize();
        playerAddEnergyPresenter.Initialize();
        playerPunchPresenter.Initialize();
        runnerResultMoneyPresenter.Initialize();

        obstaclePresenter.Initialize();
        obstacleSpawnerPresenter.Initialize();

        leafEffectPresenter.Initialize();

        runnerExitPresenter.Initialize();

        runnerGameResultPresenter.Initialize();

        stateRunnerMachine.Initialize();


        /////
        gameSessionPresenter.SetGame(2);
        runnerResultMoneyPresenter.Reset();
        ////
    }

    private void ActivateEvents()
    {
        ActivateTransitionsSceneEvents();
    }

    private void DeactivateEvents()
    {
        DeactivateTransitionsSceneEvents();
    }

    private void ActivateTransitionsSceneEvents()
    {
        runnerExitPresenter.OnExit += HandleGoToMenu;
    }

    private void DeactivateTransitionsSceneEvents()
    {
        runnerExitPresenter.OnExit -= HandleGoToMenu;
    }

    public void Dispose()
    {
        sceneRoot.Dispose();

        DeactivateEvents();

        bankPresenter.Dispose();
        particleEffectPresenter.Dispose();

        gameSessionPresenter.Dispose();
        backgroundRandomPresenter?.Dispose();

        scrollBackgroundPresenter?.Dispose();
        playerRunnerDeadZonePresenter?.Dispose();
        playerEnergyPresenter?.Dispose();
        playerRunnerAnimationPresenter?.Dispose();
        playerRunnerMoveAutoPresenter?.Dispose();
        playerRunnerMovePresenter?.Dispose();
        touchSystemPresenter?.Dispose();

        playerAddMoneyPresenter?.Dispose();
        playerAddEnergyPresenter?.Dispose();
        playerPunchPresenter?.Dispose();
        runnerResultMoneyPresenter?.Dispose();

        obstaclePresenter?.Dispose();
        obstacleSpawnerPresenter?.Dispose();

        runnerExitPresenter?.Dispose();

        leafEffectPresenter?.Dispose();

        runnerGameResultPresenter?.Dispose();

        stateRunnerMachine?.Dispose();
    }

    private void OnApplicationQuit()
    {
        gameSessionPresenter.Reset();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Output

    public event Action OnGoToMenu;

    private void HandleGoToMenu()
    {
        sceneRoot.CloseBalancePanel();
        sceneRoot.CloseEnergyPanel();

        sceneRoot.Deactivate();
        soundPresenter.Dispose();
        OnGoToMenu?.Invoke();
    }

    #endregion
}
