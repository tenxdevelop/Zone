/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.MVVM;
using SkyForge.Infrastructure.Reactive;
using System;

namespace Zone
{

    public interface IUIGameplayMenuPanelViewModel : IViewModel
    {
        event Action<object> OnOpenSettingsEvent;
        SingleReactiveProperty<bool> IsOpenMenuPanel { get; }
        void ShowMenuPanel(object sender);
        void HideMenuPanel(object sender);
        void ContinueGame(object sender);
        void ExitToMenu(object sender);
        void OpenSettings(object sender);
    }
}
