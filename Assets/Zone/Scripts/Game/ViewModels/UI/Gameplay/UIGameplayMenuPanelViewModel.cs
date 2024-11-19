/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using SkyForge.Infrastructure.MVVM;
using System;

namespace Zone
{

    public class UIGameplayMenuPanelViewModel : IUIGameplayMenuPanelViewModel
    {
        public SingleReactiveProperty<bool> IsOpenMenuPanel { get; private set; } = new();

        public event Action<object> OnOpenSettingsEvent;

        private Action<object> m_onExitToMenuCallBack;
        private Action<object> m_onContinueGameCallBack;

        public UIGameplayMenuPanelViewModel(Action<object> onExitToMenuCallBack, Action<object> onContinueGameCallBack)
        {
            m_onExitToMenuCallBack = onExitToMenuCallBack;
            m_onContinueGameCallBack = onContinueGameCallBack;
        }

        [ReactiveMethod]
        public void ContinueGame(object sender)
        {
            HideMenuPanel(sender);
            m_onContinueGameCallBack?.Invoke(sender);
        }

        [ReactiveMethod]
        public void ExitToMenu(object sender)
        {
            m_onExitToMenuCallBack?.Invoke(sender);
        }

        public void HideMenuPanel(object sender)
        {
            IsOpenMenuPanel.SetValue(sender, false);
        }

        [ReactiveMethod]
        public void OpenSettings(object sender)
        {
            HideMenuPanel(sender);
            OnOpenSettingsEvent?.Invoke(sender);
        }

        public void ShowMenuPanel(object sender)
        {
            IsOpenMenuPanel.SetValue(sender, true);
        }

        public void Dispose()
        {

        }
    }
}
