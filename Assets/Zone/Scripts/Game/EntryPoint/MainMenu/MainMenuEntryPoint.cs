/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using System.Collections;
using UnityEngine;
using SkyForge;

namespace Zone
{
    public sealed class MainMenuEntryPoint : MonoBehaviour, IEntryPoint
    {
        private DIContainer m_container;
        private SingleReactiveProperty<MainMenuExitParams> m_sceneExitParams = new ();

        public IEnumerator Intialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams)
        {
            var mainMenuSceneEnterParams = sceneEnterParams.As<MainMenuEnterParams>();
            m_container = parentContainer;

            MainMenuServiceRegistration.RegisterService(m_container, mainMenuSceneEnterParams);
            MainMenuViewModelRegistration.RegisterViewModel(m_container);
            MainMenuViewBind.LoadAndBindView(m_container);

            yield return null;
        }

        public IObservable<SceneExitParams> Run()
        {
            return m_sceneExitParams;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                LoadGameplayEnterParams(null);
            }
        }

        private void LoadGameplayEnterParams(object sender)
        {
            var gameplayEnterParams = new GameplayEnterParams();
            var sceneExitParams = new MainMenuExitParams(gameplayEnterParams);
            m_sceneExitParams.SetValue(sender, sceneExitParams);
        }

        private void OnDestroy()
        {
            m_container.Dispose();
        }
    }
}
