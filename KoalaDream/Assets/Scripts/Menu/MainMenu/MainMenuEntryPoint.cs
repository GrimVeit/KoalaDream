using System;
using System.Collections;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private PictureGroup pictureGroup;
    [SerializeField] private UIMainMenuRoot menuRootPrefab;

    private UIMainMenuRoot sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private RoomTrackerPresenter roomTrackerPresenter;
    private RoomLightPresenter roomLightPresenter;
    private PlayerMarkerNavigationPresenter playerMarkerNavigationPresenter;
    private GameMarkerNavigationPresenter gameMarkerNavigationPresenter;
    private MoveMarkerPresenter moveMarkerPresenter;

    private PlayerMovePresenter playerMovePresenter;
    private PlayerAnimationPresenter playerAnimationPresenter;
    private ManualMovePresenter manualMovePresenter;
    private AutoMovePresenter autoMovePresenter;
    private PlayerVisiblePresenter playerVisiblePresenter;
    private PlayerSleepAnimationPresenter playerSleepAnimationPresenter;

    private StorePicturesPresenter storePicturesPresenter;
    private PicturesVisualPresenter picturesVisualPresenter;
    private PicturesShowVisualPresenter picturesShowVisualPresenter;
    private PicturesOpenVisualPresenter picturesOpenVisualPresenter;
    private PicturePreviewPresenter picturePreviewPresenter;

    private GameSessionPresenter gameSessionPresenter;

    private PicturePuzzleAccessPresenter picturePuzzleAccessPresenter;
    private BedGameAccessPresenter bedGameAccessPresenter;

    private RoomNamePresenter roomNamePresenter;

    private StateMenuMachine stateMenuMachine;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = menuRootPrefab;

        //uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter(new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS), viewContainer.GetView<SoundView>());

        particleEffectPresenter = new ParticleEffectPresenter(new ParticleEffectModel(), viewContainer.GetView<ParticleEffectView>());

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());

        roomTrackerPresenter = new RoomTrackerPresenter(new RoomTrackerModel(), viewContainer.GetView<RoomTrackerView>());
        roomLightPresenter = new RoomLightPresenter(new RoomLightModel(roomTrackerPresenter), viewContainer.GetView<RoomLightView>());
        playerMarkerNavigationPresenter = new PlayerMarkerNavigationPresenter(new PlayerMarkerNavigationModel(roomTrackerPresenter), viewContainer.GetView<PlayerMarkerNavigationView>());
        gameMarkerNavigationPresenter = new GameMarkerNavigationPresenter(new GameMarkerNavigationModel(roomTrackerPresenter), viewContainer.GetView<GameMarkerNavigationView>());
        moveMarkerPresenter = new MoveMarkerPresenter(new MoveMarkerModel(), viewContainer.GetView<MoveMarkerView>());

        playerMovePresenter = new PlayerMovePresenter(new PlayerMoveModel(), viewContainer.GetView<PlayerMoveView>());
        playerAnimationPresenter = new PlayerAnimationPresenter(new PlayerAnimationModel(playerMovePresenter), viewContainer.GetView<PlayerAnimationView>());
        manualMovePresenter = new ManualMovePresenter(new ManualMoveModel(), viewContainer.GetView<ManualMoveView>());
        autoMovePresenter = new AutoMovePresenter(new AutoMoveModel(playerMovePresenter, playerMovePresenter), viewContainer.GetView<AutoMoveView>());
        playerVisiblePresenter = new PlayerVisiblePresenter(new PlayerVisibleModel(), viewContainer.GetView<PlayerVisibleView>());
        playerSleepAnimationPresenter = new PlayerSleepAnimationPresenter(new PlayerSleepAnimationModel(), viewContainer.GetView<PlayerSleepAnimationView>());

        storePicturesPresenter = new StorePicturesPresenter(new StorePicturesModel(pictureGroup));
        picturesVisualPresenter = new PicturesVisualPresenter(new PicturesVisualModel(storePicturesPresenter, storePicturesPresenter), viewContainer.GetView<PicturesVisualView>());
        picturesShowVisualPresenter = new PicturesShowVisualPresenter(new PicturesShowVisualModel(storePicturesPresenter), viewContainer.GetView<PicturesShowVisualView>());
        picturesOpenVisualPresenter = new PicturesOpenVisualPresenter(new PicturesOpenVisualModel(storePicturesPresenter), viewContainer.GetView<PicturesOpenVisualView>());
        picturePreviewPresenter = new PicturePreviewPresenter(new PicturePreviewModel(storePicturesPresenter, storePicturesPresenter));

        roomNamePresenter = new RoomNamePresenter(new RoomNameModel(roomTrackerPresenter), viewContainer.GetView<RoomNameView>());

        gameSessionPresenter = new GameSessionPresenter(new GameSesionModel(PlayerPrefsKeys.GAME_TYPE));

        picturePuzzleAccessPresenter = new PicturePuzzleAccessPresenter(new PicturePuzzleAccessModel(bankPresenter, storePicturesPresenter), viewContainer.GetView<PicturePuzzleAccessView>());
        bedGameAccessPresenter = new BedGameAccessPresenter(new BedGameAccessModel(), viewContainer.GetView<BedGameAccessView>());

        stateMenuMachine = new StateMenuMachine(
            autoMovePresenter, 
            manualMovePresenter, 
            playerMovePresenter, 
            playerMovePresenter, 
            gameMarkerNavigationPresenter, 
            playerMarkerNavigationPresenter, 
            moveMarkerPresenter, 
            storePicturesPresenter, 
            sceneRoot, 
            bedGameAccessPresenter,
            playerVisiblePresenter,
            playerSleepAnimationPresenter,
            playerSleepAnimationPresenter,
            gameSessionPresenter,
            playerAnimationPresenter);

        ActivateEvents();

        soundPresenter.Initialize();
        sceneRoot.Initialize();
        particleEffectPresenter.Initialize();
        bankPresenter.Initialize();

        roomNamePresenter.Initialize();

        playerSleepAnimationPresenter.Initialize();
        playerVisiblePresenter.Initialize();
        autoMovePresenter.Initialize();
        manualMovePresenter.Initialize();
        playerAnimationPresenter.Initialize();
        playerMovePresenter.Initialize();

        moveMarkerPresenter.Initialize();
        gameMarkerNavigationPresenter.Initialize();
        playerMarkerNavigationPresenter.Initialize();
        roomLightPresenter.Initialize();
        roomTrackerPresenter.Initialize();
        roomTrackerPresenter.Activate();

        gameSessionPresenter.Initialize();

        bedGameAccessPresenter.Initialize();
        picturePuzzleAccessPresenter.Initialize();
        picturePreviewPresenter.Initialize();
        picturesOpenVisualPresenter.Initialize();
        picturesShowVisualPresenter.Initialize();
        picturesVisualPresenter.Initialize();
        storePicturesPresenter.Initialize();

        stateMenuMachine.Initialize();
    }

    private void ActivateEvents()
    {
        sceneRoot.Activate();

        ActivateTransitions();
    }

    private void DeactivateEvents()
    {
        sceneRoot.Deactivate();

        DeactivateTransitions();
    }

    private void ActivateTransitions()
    {
        picturePuzzleAccessPresenter.OnActivatePuzzle += HandleGoToGame_Puzzle;
        playerSleepAnimationPresenter.OnEndActivate += HandleGoToGame_Runner;
    }

    private void DeactivateTransitions()
    {
        picturePuzzleAccessPresenter.OnActivatePuzzle -= HandleGoToGame_Puzzle;
        playerSleepAnimationPresenter.OnEndActivate -= HandleGoToGame_Runner;
    }

    private void Deactivate()
    {
        sceneRoot.Deactivate();
        soundPresenter?.Dispose();
    }

    private void Dispose()
    {
        DeactivateEvents();

        soundPresenter?.Dispose();
        sceneRoot?.Dispose();
        particleEffectPresenter?.Dispose();
        bankPresenter?.Dispose();

        roomNamePresenter?.Dispose();

        playerSleepAnimationPresenter?.Dispose();
        playerVisiblePresenter?.Dispose();
        autoMovePresenter.Dispose();
        manualMovePresenter.Dispose();
        playerAnimationPresenter.Dispose();
        playerMovePresenter.Dispose();

        moveMarkerPresenter.Dispose();
        gameMarkerNavigationPresenter.Dispose();
        playerMarkerNavigationPresenter.Dispose();
        roomLightPresenter.Dispose();
        roomTrackerPresenter.Dispose();

        gameSessionPresenter.Dispose();

        bedGameAccessPresenter?.Dispose();
        picturePuzzleAccessPresenter?.Dispose();
        picturePreviewPresenter?.Dispose();
        picturesOpenVisualPresenter?.Dispose();
        picturesShowVisualPresenter?.Dispose();
        picturesVisualPresenter.Dispose();
        storePicturesPresenter.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Output

    public event Action OnGoToGame_Puzzle;
    public event Action OnGoToGame_Runner;

    private void HandleGoToGame_Puzzle()
    {
        Deactivate();
        OnGoToGame_Puzzle?.Invoke();
    }

    private void HandleGoToGame_Runner()
    {
        Deactivate();
        OnGoToGame_Runner?.Invoke();
    }

    #endregion
}
