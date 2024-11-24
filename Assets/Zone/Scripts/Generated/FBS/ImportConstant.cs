/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.FlatBuffers;

namespace Zone
{
    public class ImportConstant : IImportConstants
    {
        public const string MAIN_SPREAD_SHEET_ID = "1oSqk1qDgVmlJX3Hsh-VdhCvkzMdQNYpc3l5RxNGEngw";

        public const string CREDENTIAL_PATH = "GoogleConfig.json";
        public const string SETTINGS_FOLDER = "Assets/Zone/Settings";
        public const string RESOURCES_FOLDER = "Assets/Resources";
        public const string SETTINGS_FILE_NAME = "settings.bytes";

        public string GetCredentialsPath() => CREDENTIAL_PATH;

        public string GetResourcesFolder() => RESOURCES_FOLDER;

        public string GetSettingFolder() => SETTINGS_FOLDER;

        public string GetSettingsFileName() => SETTINGS_FILE_NAME;
    }
}
