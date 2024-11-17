/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using UnityEngine.SceneManagement;
using SkyForge.Infrastructure;
using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using SkyForge;

namespace Zone.Services
{
    public class SceneService : ISceneService
    {
        public const string BOOTSTRAP_SCENE = "Bootstrap";
        public const string MAIN_MENU_SCENE = "MainMenu";
        public const string GAMEPLAY_SCENE = "Gameplay";

        public event UnityAction<Scene, LoadSceneMode, SceneEnterParams> LoadSceneEvent;

        private SceneEnterParams m_targerEnterParams;

        public SceneService()
        {
            SceneManager.sceneLoaded += OnLoadScene;
        }

        public void Dispose()
        {
            SceneManager.sceneLoaded -= OnLoadScene;
        }

        public string GetCurrentSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }

        public IEnumerator LoadMainMenu(MainMenuEnterParams mainMenuEnterParams)
        {
            m_targerEnterParams = mainMenuEnterParams;
            yield return LoadScene(BOOTSTRAP_SCENE);
            yield return LoadScene(MAIN_MENU_SCENE);
        }

        public IEnumerator LoadGameplay(GameplayEnterParams gameplayEnterParams)
        {
            m_targerEnterParams = gameplayEnterParams;
            yield return LoadScene(BOOTSTRAP_SCENE);
            yield return LoadScene(GAMEPLAY_SCENE);
        }

        public void LoadBootstrap()
        {
            Time.timeScale = 0.0f;
        }

        public void StartScene(IEntryPoint entryPoint, Coroutines coroutines)
        {
            entryPoint.Run().Subscribe(sceneExitParams =>
            {
                if (sceneExitParams.TargetEnterParams is GameplayEnterParams)
                    coroutines.StartCoroutine(LoadGameplay(sceneExitParams.TargetEnterParams.As<GameplayEnterParams>()));
                else if (sceneExitParams.TargetEnterParams is MainMenuEnterParams)
                    coroutines.StartCoroutine(LoadMainMenu(sceneExitParams.TargetEnterParams.As<MainMenuEnterParams>()));
            });

            Time.timeScale = 1.0f;
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        private void OnLoadScene(Scene scene, LoadSceneMode loadSceneMode)
        {
            LoadSceneEvent?.Invoke(scene, loadSceneMode, m_targerEnterParams);
        }
    }
}
