/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using SkyForge.Infrastructure.MVVM;
using System;

namespace Zone
{
    public interface IUIMenuSettingsViewModel : IViewModel
    {
        event Action<object> OnCloseMenuSettingsEvent;
        SingleReactiveProperty<bool> IsOpenMenuSettings { get; }
        void OpenMenuSettings(object sender);
        void CloseMenuSettings(object sender);

    }
}
