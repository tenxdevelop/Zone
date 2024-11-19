/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.MVVM;

namespace Zone
{
    public interface IUIMainMenuViewModel : IViewModel
    {
        IUIMenuPanelViewModel MenuPanelViewModel { get; }
        IUIMenuSettingsViewModel MenuSettingsViewModel { get; }
    }
}
