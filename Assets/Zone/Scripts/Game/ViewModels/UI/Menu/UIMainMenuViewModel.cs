/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.MVVM;
using System;

namespace Zone
{
    public class UIMainMenuViewModel : IUIMainMenuViewModel
    {
        [SubViewModel(typeof(UIMenuPanelViewModel))]
        public IUIMenuPanelViewModel MenuPanelViewModel { get; private set; }

        [SubViewModel(typeof(UIMenuSettingsViewModel))]
        public IUIMenuSettingsViewModel MenuSettingsViewModel { get; private set; }

        public UIMainMenuViewModel(Action<object> onStartGameCallBack)
        {
            MenuPanelViewModel = new UIMenuPanelViewModel(onStartGameCallBack);
            MenuSettingsViewModel = new UIMenuSettingsViewModel();

            MenuPanelViewModel.OnOpenSettingsEvent += MenuSettingsViewModel.OpenMenuSettings;
            MenuSettingsViewModel.OnCloseMenuSettingsEvent += MenuPanelViewModel.ShowMenuPanel;
        }

        public void Dispose()
        {
            MenuPanelViewModel.OnOpenSettingsEvent -= MenuSettingsViewModel.OpenMenuSettings;
            MenuSettingsViewModel.OnCloseMenuSettingsEvent -= MenuPanelViewModel.ShowMenuPanel;
        }

    }
}
