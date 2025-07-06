using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntryPoint_Runner : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
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
    private PlayerEnergyPresenter playerEnergyPresenter;
    private ScrollBackgroundPresenter scrollBackgroundPresenter;

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
        playerEnergyPresenter = new PlayerEnergyPresenter(new PlayerEnergyModel(touchSystemPresenter), viewContainer.GetView<PlayerEnergyView>());
        scrollBackgroundPresenter = new ScrollBackgroundPresenter(new ScrollBackgroundModel(), viewContainer.GetView<ScrollBackgroundView>());
        
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
        playerEnergyPresenter.Initialize();
        playerRunnerMovePresenter.Initialize();
        touchSystemPresenter.Initialize();

        gameSessionPresenter.SetGame(2);

        sceneRoot.OpenBalancePanel();
        sceneRoot.OpenEnergyPanel();
        scrollBackgroundPresenter.ActivateScroll();
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
        sceneRoot.OnClickToExit_Balance += HandleGoToMenu;
    }

    private void DeactivateTransitionsSceneEvents()
    {
        sceneRoot.OnClickToExit_Balance -= HandleGoToMenu;
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
        playerEnergyPresenter?.Dispose();
        playerRunnerMovePresenter?.Dispose();
        touchSystemPresenter?.Dispose();
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
