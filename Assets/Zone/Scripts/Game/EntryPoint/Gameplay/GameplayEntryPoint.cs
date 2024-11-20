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
        [SerializeField] private PlayerView m_playerView;
        private DIContainer m_container;
        private SingleReactiveProperty<GameplayExitParams> m_sceneExitParams = new ();

        private IPlayerViewModel m_playerViewModel;
        public IEnumerator Intialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams)
        {
            var gameplayEnterParams = sceneEnterParams.As<GameplayEnterParams>();

            m_container = parentContainer;

            GameplayServiceRegistration.RegisterService(m_container, gameplayEnterParams);
            GameplayViewModelRegistration.RegisterViewModel(m_container);
            m_container.RegisterSingleton<IUIGameplayMenuViewModel>(factory => new UIGameplayMenuViewModel(LoadMainMenuParams));

            GameplayViewBind.LoadAndBindView(m_container);

            m_playerViewModel = m_container.Resolve<IPlayerService>().PlayerViewModel.Value;
            m_playerView.Bind(m_playerViewModel);

            yield return null;
        }

        public IObservable<SceneExitParams> Run()
        {

            return m_sceneExitParams;
        }

        private Vector3 direction = Vector3.zero;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                var uIGameplayMenuViewModel = m_container.Resolve<IUIGameplayMenuViewModel>();
                uIGameplayMenuViewModel.OpenMenu(this);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                direction += Vector3.forward;               
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                direction += Vector3.back;
                
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                direction += Vector3.right;
                
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                direction += Vector3.left;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                direction -= Vector3.forward;

            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                direction -= Vector3.back;

            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                direction -= Vector3.right;

            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                direction -= Vector3.left;
            }

            m_playerViewModel.Move(direction);
        }

        private void LoadMainMenuParams(object sender)
        {
            var gameStateProvider = m_container.Resolve<IGameStateProvider>();
            gameStateProvider.SaveState();

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
