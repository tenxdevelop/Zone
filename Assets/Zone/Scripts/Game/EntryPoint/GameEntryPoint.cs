/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.SceneManagement;
using SkyForge.Infrastructure;
using System.Collections;
using Zone.Services;
using UnityEngine;
using SkyForge;


namespace Zone
{
    public sealed class GameEntryPoint
    {
        private static GameEntryPoint m_instance;

        private DIContainer m_rootContainer;
        private Coroutines m_coroutines;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Start()
        {
            Application.targetFrameRate = 144;


            m_instance = new GameEntryPoint();
            m_instance.Init();
        }

        private GameEntryPoint()
        {
            m_rootContainer = new DIContainer();

            RegisterService(m_rootContainer);
            RegisterViewModel(m_rootContainer);
            BindView(m_rootContainer);

            //Init Coroutines
            m_coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(m_coroutines.gameObject);
            m_rootContainer.RegisterInstance(m_coroutines);
            //Load Settings

        }

        private void Init()
        {
            var sceneService = m_rootContainer.Resolve<ISceneService>();
            sceneService.LoadSceneEvent += OnLoadScene;

            if (sceneService.GetCurrentSceneName() != SceneService.BOOTSTRAP_SCENE)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }

            var mainMenuEnterParams = new MainMenuEnterParams();
            m_coroutines.StartCoroutine(sceneService.LoadMainMenu(mainMenuEnterParams));
        }

        private void RegisterViewModel(DIContainer container)
        {
            container.RegisterSingleton<ISceneService>(factory => new SceneService());
        }


        private void RegisterService(DIContainer container)
        {

        }

        private void BindView(DIContainer contaier)
        {

        }

        private void OnLoadScene(Scene scene, LoadSceneMode mode, SceneEnterParams sceneEnterParams)
        {
            var sceneService = m_rootContainer.Resolve<ISceneService>();
            var sceneName = scene.name;

            if (sceneName.Equals(SceneService.BOOTSTRAP_SCENE))
                LoadingBootstrap(sceneService);
            else if (sceneName.Equals(SceneService.MAIN_MENU_SCENE))
                m_coroutines.StartCoroutine(LoadingMainMenu(sceneService, sceneEnterParams.As<MainMenuEnterParams>()));
            else if (sceneName.Equals(SceneService.GAMEPLAY_SCENE))
                m_coroutines.StartCoroutine(LoadingGameplay(sceneService, sceneEnterParams.As<GameplayEnterParams>()));
        }

        private void LoadingBootstrap(ISceneService sceneService)
        {
            sceneService.LoadBootstrap();
        }

        private IEnumerator LoadingMainMenu(ISceneService sceneService, MainMenuEnterParams mainMenuEnterParams)
        {
            var mainMenuContainer = new DIContainer(m_rootContainer);

            var mainMenuEntyPoint = UnityExtention.GetEntryPoint<MainMenuEntryPoint>();
            yield return mainMenuEntyPoint.Intialization(mainMenuContainer, mainMenuEnterParams);

            sceneService.StartScene(mainMenuEntyPoint, m_coroutines);
        }

        private IEnumerator LoadingGameplay(ISceneService sceneService, GameplayEnterParams gameplayEnterParams) 
        {
            var gameplayContainer = new DIContainer(m_rootContainer);

            var gameplayEntryPoint = UnityExtention.GetEntryPoint<GameplayEntryPoint>();
            yield return gameplayEntryPoint.Intialization(gameplayContainer, gameplayEnterParams);

            sceneService.StartScene(gameplayEntryPoint, m_coroutines);
        }

    }
}