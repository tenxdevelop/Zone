/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using SkyForge.Infrastructure.MVVM;
using System;

namespace Zone
{
    public interface IUIMenuPanelViewModel : IViewModel
    {
        event Action<object> OnOpenSettingsEvent;
        SingleReactiveProperty<bool> IsOpenMenuPanel { get; }
        void ShowMenuPanel(object sender);
        void HideMenuPanel(object sender);

        void StartGame(object sender);
        void OpenSettings(object sender);
        void ExitGame(object sender);

    }
}
