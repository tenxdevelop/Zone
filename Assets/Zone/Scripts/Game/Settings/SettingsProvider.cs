/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.FlatBuffers;
using System.Threading.Tasks;
using Google.FlatBuffers;
using Zone.Services;
using UnityEngine;

namespace Zone
{
    internal class SettingsProvider : ISettingsProvider
    {
        public ApplicationSettings ApplicationSettings { get; private set; }

        public GameSettings GameSettings { get; private set; }

        private ILoadService m_loadService;

        public SettingsProvider(ILoadService loadService)
        {
            m_loadService = loadService;
            ApplicationSettings = loadService.LoadScriptableObject<ApplicationSettings>(LoadService.SRIPTABLE_OBJECT_APPLICATION_SETTINGS);
            
        }

        public Task<GameSettings> LoadGameSettings()
        {
            var byteBuffer = m_loadService.LoadFlatBufferResource(LoadService.FLATBUFFER_GAME_SETTINGS);
            if (byteBuffer is null)
                SettingsImportUtils.ImportAllConfigs<GameSettings, GameSettingsT>();

            byteBuffer = m_loadService.LoadFlatBufferResource(LoadService.FLATBUFFER_GAME_SETTINGS);

            if (byteBuffer is null)
            {
                Debug.LogError("Can't load FlatBuffer gameSettings config");
                return Task.FromResult(new GameSettings());
            }

            var flatBuffer = new ByteBuffer(byteBuffer);
            GameSettings = GameSettings.GetRootAsGameSettings(flatBuffer);
            return Task.FromResult(GameSettings);
        }

        public void Dispose()
        {
            
        }
    }
}
