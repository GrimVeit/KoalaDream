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

    private StorePicturesPresenter storePicturesPresenter;
    private PicturesVisualPresenter picturesVisualPresenter;
    private PicturesShowVisualPresenter picturesShowVisualPresenter;
    private PicturesOpenVisualPresenter picturesOpenVisualPresenter;
    private PicturePuzzleAccessPresenter picturePuzzleAccessPresenter;

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

        storePicturesPresenter = new StorePicturesPresenter(new StorePicturesModel(pictureGroup));
        picturesVisualPresenter = new PicturesVisualPresenter(new PicturesVisualModel(storePicturesPresenter, storePicturesPresenter), viewContainer.GetView<PicturesVisualView>());
        picturesShowVisualPresenter = new PicturesShowVisualPresenter(new PicturesShowVisualModel(storePicturesPresenter), viewContainer.GetView<PicturesShowVisualView>());
        picturesOpenVisualPresenter = new PicturesOpenVisualPresenter(new PicturesOpenVisualModel(storePicturesPresenter), viewContainer.GetView<PicturesOpenVisualView>());
        picturePuzzleAccessPresenter = new PicturePuzzleAccessPresenter(new PicturePuzzleAccessModel(bankPresenter, storePicturesPresenter), viewContainer.GetView<PicturePuzzleAccessView>());

        stateMenuMachine = new StateMenuMachine(autoMovePresenter, manualMovePresenter, playerMovePresenter, playerMovePresenter, gameMarkerNavigationPresenter, playerMarkerNavigationPresenter, moveMarkerPresenter, storePicturesPresenter, sceneRoot);

        ActivateEvents();

        soundPresenter.Initialize();
        sceneRoot.Initialize();
        particleEffectPresenter.Initialize();
        bankPresenter.Initialize();

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

        picturePuzzleAccessPresenter.Initialize();
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
    }

    private void DeactivateTransitions()
    {
        picturePuzzleAccessPresenter.OnActivatePuzzle -= HandleGoToGame_Puzzle;
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

        autoMovePresenter.Dispose();
        manualMovePresenter.Dispose();
        playerAnimationPresenter.Dispose();
        playerMovePresenter.Dispose();

        moveMarkerPresenter.Dispose();
        gameMarkerNavigationPresenter.Dispose();
        playerMarkerNavigationPresenter.Dispose();
        roomLightPresenter.Dispose();
        roomTrackerPresenter.Dispose();

        picturePuzzleAccessPresenter?.Dispose();
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

    private void HandleGoToGame_Puzzle()
    {
        Deactivate();
        OnGoToGame_Puzzle?.Invoke();
    }

    #endregion
}
