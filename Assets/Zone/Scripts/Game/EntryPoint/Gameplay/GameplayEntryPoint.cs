/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using System.Collections;
using UnityEngine;
using SkyForge;

namespace Zone
{

    public sealed class GameplayEntryPoint : MonoBehaviour, IEntryPoint
    {
        private DIContainer m_container;
        private SingleReactiveProperty<GameplayExitParams> m_sceneExitParams = new ();
        public IEnumerator Intialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams)
        {
            var gameplayEnterParams = sceneEnterParams.As<GameplayEnterParams>();

            m_container = parentContainer;

            GameplayServiceRegistration.RegisterService(m_container, gameplayEnterParams);
            GameplayViewModelRegistration.RegisterViewModel(m_container);
            GameplayViewBind.LoadAndBindView(m_container);
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
                LoadMainMenuParams(null);
            }
        }

        private void LoadMainMenuParams(object sender)
        {
            var mainMenuEnterParams = new MainMenuEnterParams();
            var sceneExitParams = new GameplayExitParams(mainMenuEnterParams);
            m_sceneExitParams.SetValue(sender, sceneExitParams);
        }

        private void OnDestroy()
        {
            m_container.Dispose();
        }
    }
}
