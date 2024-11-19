/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.MVVM;
using SkyForge.Infrastructure.Reactive;

namespace Zone
{

    public interface IUIGameplayMenuViewModel : IViewModel
    {
        SingleReactiveProperty<bool> IsOpenGameplayMenu { get; }
        IUIGameplayMenuPanelViewModel GameplayMenuPanelViewModel { get; }
        IUIMenuSettingsViewModel MenuSettingsViewModel { get; }
        void OpenMenu(object sender);
    }
}
