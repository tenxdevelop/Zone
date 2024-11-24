/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.FlatBuffers;
using UnityEditor;

namespace Zone
{
    public static class ImportingMenu
    {
        [MenuItem("SkyForge/FlatBuffers/GoogleSheet Import/Import All Config")]
        public static void ImportAllConfigFromGoogleSheet()
        {
            SettingsImportUtils.ImportAllConfigs<GameSettings, GameSettingsT>();
        }

        [MenuItem("SkyForge/FlatBuffers/GoogleSheet Import/Import PlayerConfig")]
        public static void ImportPlayerConfigFromGoogleSheet()
        {
            var importer = new PlayerFlatBufferImporter();
            SettingsImportUtils.ImportConfig(importer);
        }
    }
}
