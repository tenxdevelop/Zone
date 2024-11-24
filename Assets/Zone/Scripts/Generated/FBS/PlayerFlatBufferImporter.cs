/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.FlatBuffers;
using System.Threading.Tasks;
using Zone.Gameplay;
using System;

namespace Zone
{
    public class PlayerFlatBufferImporter : ProjectGoogleSheetImporter<GameSettings, GameSettingsT>, IImporter<GameSettings, GameSettingsT>
    {
        private const string SPEED_HEAD = "Speed";
        protected override string settingsFileName => "PlayerSettings.bytes";

        private PlayerSettingsT m_currentPlayerSettings;
        public PlayerFlatBufferImporter() : base(new FlatBufferPacker(), new ImportConstant(), ImportConstant.MAIN_SPREAD_SHEET_ID, "Player") 
        {
                                 
        }

        public void AddToSettings(GameSettingsT settings)
        {
            settings.PlayerSettings = LocalSettings.PlayerSettings;
        }

        public async Task DownloadAndParse()
        {
            LocalSettings = new GameSettingsT();

            await DownloadAndParceSheet();
        }

        protected override void ParseCell(string header, string cellData)
        {
            switch (header)
            {
                case SPEED_HEAD:
                    m_currentPlayerSettings = new PlayerSettingsT
                    {
                        Speed = Convert.ToSingle(cellData)
                    };
                    LocalSettings.PlayerSettings = m_currentPlayerSettings;
                    return;
            }
        }
    }
}
