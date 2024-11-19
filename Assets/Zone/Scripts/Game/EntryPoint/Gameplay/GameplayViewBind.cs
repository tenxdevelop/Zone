/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using Zone.Services;
using UnityEngine;
using SkyForge;

namespace Zone
{
    public static class GameplayViewBind
    {
        
        public static void LoadAndBindView(DIContainer container)
        {
            var loadService = container.Resolve<ILoadService>();

            //Bind UIGameplayRoot
            var uIGameplayRootViewModel = container.Resolve<IUIGameplayRootViewModel>();
            var uIGameplayRootPrefab = loadService.LoadPrefab<UIGameplayRootView>(LoadService.PREFAB_UI_GAMEPLAY_ROOT);
            var uIGameplayRootView = Object.Instantiate(uIGameplayRootPrefab);
            uIGameplayRootView.Bind(uIGameplayRootViewModel);

            var uIRootViewModel = container.Resolve<IUIRootViewModel>();
            uIRootViewModel.AttachSceneUIStatic(uIGameplayRootView, true);
        }
    }
}
