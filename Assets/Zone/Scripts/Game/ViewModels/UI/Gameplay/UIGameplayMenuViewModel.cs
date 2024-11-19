/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using SkyForge.Infrastructure.MVVM;
using UnityEngine;
using System;

namespace Zone
{
    public class UIGameplayMenuViewModel : IUIGameplayMenuViewModel
    {
        public SingleReactiveProperty<bool> IsOpenGameplayMenu { get; private set; } = new();

        [SubViewModel(typeof(UIGameplayMenuPanelViewModel))]
        public IUIGameplayMenuPanelViewModel GameplayMenuPanelViewModel { get; private set; }

        [SubViewModel(typeof(UIMenuSettingsViewModel))]
        public IUIMenuSettingsViewModel MenuSettingsViewModel { get; private set; }

        public UIGameplayMenuViewModel(Action<object> onExitToMenuCallBack)
        {
            GameplayMenuPanelViewModel = new UIGameplayMenuPanelViewModel(onExitToMenuCallBack, OnContinueGameCallBack);
            MenuSettingsViewModel = new UIMenuSettingsViewModel();
            GameplayMenuPanelViewModel.OnOpenSettingsEvent += MenuSettingsViewModel.OpenMenuSettings;
            MenuSettingsViewModel.OnCloseMenuSettingsEvent += GameplayMenuPanelViewModel.ShowMenuPanel;
        }

        public void OpenMenu(object sender)
        {
            Time.timeScale = 0.0f;
            IsOpenGameplayMenu.SetValue(sender, true);
            GameplayMenuPanelViewModel.ShowMenuPanel(sender);
        }

        public void Dispose()
        {
            GameplayMenuPanelViewModel.OnOpenSettingsEvent -= MenuSettingsViewModel.OpenMenuSettings;
            MenuSettingsViewModel.OnCloseMenuSettingsEvent -= GameplayMenuPanelViewModel.ShowMenuPanel;
        }

        private void OnContinueGameCallBack(object sender)
        {
            IsOpenGameplayMenu.SetValue(sender, false);
            Time.timeScale = 1.0f;
        }

        
    }

}
