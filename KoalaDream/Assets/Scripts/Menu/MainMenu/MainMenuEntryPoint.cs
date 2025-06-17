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

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = menuRootPrefab;

        uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter
                    (new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS),
                    viewContainer.GetView<SoundView>());

        particleEffectPresenter = new ParticleEffectPresenter
            (new ParticleEffectModel(),
            viewContainer.GetView<ParticleEffectView>());

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());

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

    public event Action OnGoToRoulette_Mini;
    public event Action OnGoToRoulette_Euro;
    public event Action OnGoToRoulette_America;
    public event Action OnGoToRoulette_AmericaMulti;
    public event Action OnGoToRoulette_French;
    public event Action OnGoToRoulette_AmericaTracker;

    private void HandleGoToRoulette_Mini()
    {
        Deactivate();
        OnGoToRoulette_Mini?.Invoke();
    }

    private void HandleGoToRoulette_Euro()
    {
        Deactivate();
        OnGoToRoulette_Euro?.Invoke();
    }

    private void HandleGoToRoulette_America()
    {
        Deactivate();
        OnGoToRoulette_America?.Invoke();
    }

    private void HandleGoToRoulette_AmericaMulti()
    {
        Deactivate();
        OnGoToRoulette_AmericaMulti?.Invoke();
    }

    private void HandleGoToRoulette_French()
    {
        Deactivate();
        OnGoToRoulette_French?.Invoke();
    }

    private void HandleGoToRoulette_AmericaTracker()
    {
        Deactivate();
        OnGoToRoulette_AmericaTracker?.Invoke();
    }

    #endregion
}
