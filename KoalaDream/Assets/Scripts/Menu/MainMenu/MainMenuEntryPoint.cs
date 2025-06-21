using System;
using System.Collections;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private UIMainMenuRoot menuRootPrefab;

    private UIMainMenuRoot sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;
    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private RoomTrackerPresenter roomTrackerPresenter;
    private RoomLightPresenter roomLightPresenter;
    private PlayerMarkerNavigationPresenter playerMarkerNavigationPresenter;

    private void Awake()
    {
        Run(null);
    }

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = menuRootPrefab;

        //uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter
                    (new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS),
                    viewContainer.GetView<SoundView>());

        particleEffectPresenter = new ParticleEffectPresenter
            (new ParticleEffectModel(),
            viewContainer.GetView<ParticleEffectView>());

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());

        roomTrackerPresenter = new RoomTrackerPresenter(new RoomTrackerModel(), viewContainer.GetView<RoomTrackerView>());
        roomLightPresenter = new RoomLightPresenter(new RoomLightModel(roomTrackerPresenter), viewContainer.GetView<RoomLightView>());
        playerMarkerNavigationPresenter = new PlayerMarkerNavigationPresenter(new PlayerMarkerNavigationModel(roomTrackerPresenter), viewContainer.GetView<PlayerMarkerNavigationView>());

        ActivateEvents();

        soundPresenter.Initialize();
        sceneRoot.Initialize();
        particleEffectPresenter.Initialize();
        bankPresenter.Initialize();

        playerMarkerNavigationPresenter.Initialize();
        roomLightPresenter.Initialize();
        roomTrackerPresenter.Initialize();
        roomTrackerPresenter.Activate();
    }

    private void ActivateEvents()
    {
        ActivateTransitions();
    }

    private void DeactivateEvents()
    {
        DeactivateTransitions();
    }

    private void ActivateTransitions()
    {

    }

    private void DeactivateTransitions()
    {

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

        playerMarkerNavigationPresenter.Dispose();
        roomLightPresenter.Dispose();
        roomTrackerPresenter.Dispose();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    storeGameProgressPresenter.OpenGame(2);
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    storeGameProgressPresenter.OpenGame(4);
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    storeGameProgressPresenter.OpenGame(1);
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    storeGameProgressPresenter.OpenGame(6);
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    storeGameProgressPresenter.OpenGame(5);
        //}
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
