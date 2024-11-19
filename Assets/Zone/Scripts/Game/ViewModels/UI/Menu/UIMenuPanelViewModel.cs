/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using SkyForge.Infrastructure.MVVM;
using UnityEditor;
using UnityEngine;
using System;

namespace Zone
{
    public class UIMenuPanelViewModel : IUIMenuPanelViewModel
    {
        public SingleReactiveProperty<bool> IsOpenMenuPanel { get; private set; } = new();

        public event Action<object> OnOpenSettingsEvent;

        private Action<object> m_onStartGame;
        public UIMenuPanelViewModel(Action<object> onStartGame)
        {
            IsOpenMenuPanel.SetValue(null, true);
            m_onStartGame = onStartGame;
        }

        public void Dispose()
        {
            
        }

        [ReactiveMethod]
        public void ExitGame(object sender)
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        [ReactiveMethod]
        public void OpenSettings(object sender)
        {
            HideMenuPanel(sender);
            OnOpenSettingsEvent?.Invoke(sender);
        }

        [ReactiveMethod]
        public void StartGame(object sender)
        {
            m_onStartGame?.Invoke(sender);
        }

        public void HideMenuPanel(object sender)
        {
            IsOpenMenuPanel.SetValue(null, false);
        }
        

        public void ShowMenuPanel(object sender)
        {
            IsOpenMenuPanel.SetValue(null, true);
        }

        
    }
}
