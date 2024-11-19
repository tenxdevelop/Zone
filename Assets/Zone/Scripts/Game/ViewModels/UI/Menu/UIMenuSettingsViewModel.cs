/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.MVVM;
using SkyForge.Infrastructure.Reactive;
using System;

namespace Zone
{

    public class UIMenuSettingsViewModel : IUIMenuSettingsViewModel
    {
        public SingleReactiveProperty<bool> IsOpenMenuSettings { get; private set; } = new ();

        public event Action<object> OnCloseMenuSettingsEvent;

        public UIMenuSettingsViewModel()
        {
            IsOpenMenuSettings.SetValue(this, false);
        }

        [ReactiveMethod]
        public void CloseMenuSettings(object sender)
        {
            IsOpenMenuSettings.SetValue(null, false);
            OnCloseMenuSettingsEvent?.Invoke(sender);
        }

        public void OpenMenuSettings(object sender)
        {
            IsOpenMenuSettings.SetValue(null, true);
        }

        public void Dispose()
        {

        }
    }
}
