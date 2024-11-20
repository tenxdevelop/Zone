/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using UnityEngine;

namespace Zone
{
    public class PlayerPrefsGameStateProvider : IGameStateProvider
    {
        private const string GAME_STATE_KEY = nameof(GAME_STATE_KEY);
        public GameStateProxy ProxyState { get; private set; }

        private GameState m_gameStateOrigin;

        public IObservable<GameStateProxy> LoadState()
        {
            if (!PlayerPrefs.HasKey(GAME_STATE_KEY))
            {
                ProxyState = CreateGameStateFromSettings();
                Debug.Log("Game State created from settinngs: " + JsonUtility.ToJson(m_gameStateOrigin, true));

                SaveState();
            }
            else
            {
                var json = PlayerPrefs.GetString(GAME_STATE_KEY);
                m_gameStateOrigin = JsonUtility.FromJson<GameState>(json);
                ProxyState = new GameStateProxy(m_gameStateOrigin);
                Debug.Log("Game State Loaded!");
            }

            return Observable.Return(ProxyState);
        }

        public IObservable<bool> ResetState()
        {
            ProxyState = CreateGameStateFromSettings();

            SaveState();
            return Observable.Return(true);
        }

        public IObservable<bool> SaveState()
        {
            var json = JsonUtility.ToJson(m_gameStateOrigin, true);
            PlayerPrefs.SetString(GAME_STATE_KEY, json);

            return Observable.Return(true);
        }

        private GameStateProxy CreateGameStateFromSettings()
        {
            var playerSate = new PlayerState()
            {
                Position = new Vector3(368.5f, 37.73f, 47f)
            };

            m_gameStateOrigin = new GameState()
            {
                PlayerState = playerSate
            };

            var gameStateProxy = new GameStateProxy(m_gameStateOrigin);
            return gameStateProxy;
        }

        public void Dispose()
        {
            
        }
    }
}
