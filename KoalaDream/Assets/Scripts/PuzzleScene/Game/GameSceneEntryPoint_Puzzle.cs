using System;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntryPoint_Puzzle : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private PictureGroup pictureGroup;
    [SerializeField] private PuzzlesGroup puzzlesGroup;
    [SerializeField] private UIGameSceneRoot_Puzzle sceneRootPrefab;

    private UIGameSceneRoot_Puzzle sceneRoot;
    private ViewContainer viewContainer;
    private BankPresenter bankPresenter;
    private SoundPresenter soundPresenter;
    private ParticleEffectPresenter particleEffectPresenter;

    private StorePicturesPresenter storePicturesPresenter;
    private PuzzleFramePresenter puzzleFramePresenter;
    private PuzzleElementPresenter puzzleElementPresenter;
    private PuzzleDemonstrationPresenter puzzleDemonstrationPresenter;

    private GameSessionPresenter gameSessionPresenter;

    private StatePuzzleMachine statePuzzleMachine;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = sceneRootPrefab;

        //uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter(new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS), viewContainer.GetView<SoundView>());
        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());
        particleEffectPresenter = new ParticleEffectPresenter(new ParticleEffectModel(), viewContainer.GetView<ParticleEffectView>());

        storePicturesPresenter = new StorePicturesPresenter(new StorePicturesModel(pictureGroup));
        puzzleFramePresenter = new PuzzleFramePresenter(new PuzzleFrameModel(storePicturesPresenter), viewContainer.GetView<PuzzleFrameView>());
        puzzleElementPresenter = new PuzzleElementPresenter(new PuzzleElementModel(soundPresenter, storePicturesPresenter, puzzlesGroup), viewContainer.GetView<PuzzleElementView>());
        puzzleDemonstrationPresenter = new PuzzleDemonstrationPresenter(new PuzzleDemonstrationModel(storePicturesPresenter), viewContainer.GetView<PuzzleDemonstrationView>());

        gameSessionPresenter = new GameSessionPresenter(new GameSesionModel(PlayerPrefsKeys.GAME_TYPE));

        statePuzzleMachine = new StatePuzzleMachine(sceneRoot, storePicturesPresenter, puzzleFramePresenter, puzzleFramePresenter);

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Activate();

        ActivateEvents();

        sceneRoot.Initialize();

        bankPresenter.Initialize();
        soundPresenter.Initialize();
        particleEffectPresenter.Initialize();

        gameSessionPresenter.Initialize();

        puzzleDemonstrationPresenter.Initialize();
        puzzleElementPresenter.Initialize();
        puzzleFramePresenter.Initialize();
        storePicturesPresenter.Initialize();

        gameSessionPresenter.SetGame(1);

        statePuzzleMachine.Initialize();

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
        sceneRoot.OnClickToExit_ShowExit += HandleGoToMenu;
    }

    private void DeactivateTransitionsSceneEvents()
    {
        sceneRoot.OnClickToExit_ShowExit -= HandleGoToMenu;
    }

    public void Dispose()
    {
        sceneRoot.Dispose();

        DeactivateEvents();

        bankPresenter.Dispose();
        particleEffectPresenter.Dispose();

        gameSessionPresenter?.Dispose();

        puzzleDemonstrationPresenter?.Dispose();
        puzzleElementPresenter?.Dispose();
        puzzleFramePresenter?.Dispose();
        storePicturesPresenter?.Dispose();

        statePuzzleMachine?.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    #region Output

    public event Action OnGoToMenu;

    private void HandleGoToMenu()
    {
        sceneRoot.Deactivate();
        soundPresenter.Dispose();
        OnGoToMenu?.Invoke();
    }

    #endregion
}
