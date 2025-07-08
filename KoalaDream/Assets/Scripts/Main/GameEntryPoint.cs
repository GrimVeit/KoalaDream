using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    private static GameEntryPoint instance;
    private UIRootView rootView;
    private Coroutines coroutines;
    public GameEntryPoint()
    {
        coroutines = new GameObject("[Coroutines]").AddComponent<Coroutines>();
        Object.DontDestroyOnLoad(coroutines.gameObject);

        var prefabUIRoot = Resources.Load<UIRootView>("UIRootView");
        rootView = Object.Instantiate(prefabUIRoot);
        Object.DontDestroyOnLoad(rootView.gameObject);

    }

    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Autorun()
    {
        GlobalGameSettings();

        instance = new GameEntryPoint();
        instance.Run();

    }

    private static void GlobalGameSettings()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Run()
    {
        coroutines.StartCoroutine(LoadAndStartMainMenu(0));
    }

    private IEnumerator LoadAndStartMainMenu(int index)
    {
        yield return rootView.ShowLoadingScreen(index);

        yield return new WaitForSeconds(1);

        yield return LoadScene(Scenes.MAIN_MENU);

        yield return new WaitForEndOfFrame();

        var sceneEntryPoint = Object.FindObjectOfType<MainMenuEntryPoint>();

        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.OnGoToGame_Puzzle += () => coroutines.StartCoroutine(LoadAndStartGameScene_Puzzle(0));
        sceneEntryPoint.OnGoToGame_Runner += () => coroutines.StartCoroutine(LoadAndStartGameScene_Runner(1));

        yield return rootView.HideLoadingScreen(index);
    }

    private IEnumerator LoadAndStartGameScene_Puzzle(int index)
    {
        yield return rootView.ShowLoadingScreen(index);

        yield return new WaitForSeconds(1);

        yield return LoadScene(Scenes.PUZZLE);

        yield return new WaitForEndOfFrame();

        var sceneEntryPoint = Object.FindObjectOfType<GameSceneEntryPoint_Puzzle>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.OnGoToMenu += () => coroutines.StartCoroutine(LoadAndStartMainMenu(0));

        yield return rootView.HideLoadingScreen(index);
    }

    private IEnumerator LoadAndStartGameScene_Runner(int index)
    {
        yield return rootView.ShowLoadingScreen(index);

        yield return new WaitForSeconds(1);

        yield return LoadScene(Scenes.RUNNER);

        yield return new WaitForEndOfFrame();

        var sceneEntryPoint = Object.FindObjectOfType<GameSceneEntryPoint_Runner>();
        sceneEntryPoint.Run(rootView);

        sceneEntryPoint.OnGoToMenu += () => coroutines.StartCoroutine(LoadAndStartMainMenu(1));

        yield return rootView.HideLoadingScreen(index);
    }

    private IEnumerator LoadScene(string scene)
    {
        Debug.Log("Загрузка сцены - " + scene);
        yield return SceneManager.LoadSceneAsync(scene);
    }
}
