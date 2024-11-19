/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using Zone.Services;
using UnityEngine;
using SkyForge;

namespace Zone
{
    public static class MainMenuViewBind
    {
        public static void LoadAndBindView(DIContainer container)
        {
            var loadSerive = container.Resolve<ILoadService>();

            //Bind UIMenuRoot
            var uIMenuRootPrefab = loadSerive.LoadPrefab<UIMainMenuRootView>(LoadService.PREFAB_UI_MENU_ROOT);
            var uIMenuRootViewModel = container.Resolve<IUIMainMenuRootViewModel>();
            var uIMenuRootView = Object.Instantiate(uIMenuRootPrefab);
            uIMenuRootView.Bind(uIMenuRootViewModel);
            var uIRootViewModel = container.Resolve<IUIRootViewModel>();

            uIRootViewModel.AttachSceneUIStatic(uIMenuRootView, true);      
        }
    }
}
