/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.SceneManagement;
using SkyForge.Infrastructure;
using System.Collections;
using UnityEngine.Events;
using SkyForge;
using System;


namespace Zone.Services
{
    public interface ISceneService : IDisposable
    {
        event UnityAction<Scene, LoadSceneMode, SceneEnterParams> LoadSceneEvent;

        string GetCurrentSceneName();

        IEnumerator LoadMainMenu(MainMenuEnterParams mainMenuEnterParams);

        IEnumerator LoadGameplay(GameplayEnterParams gameplayEnterParams);

        void LoadBootstrap();

        void StartScene(IEntryPoint entryPoint, Coroutines coroutines);

    }

}
