/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.FlatBuffers;
using System.Collections.Generic;

namespace Zone
{
    public class FlatBuffersScriptGenerated : IFlatBuffersScriptGenerated
    {
        private const string OUTPUT_DIRECTORY = "Assets/Zone/Scripts/Generated/FBS/GenerateCode";

        private static readonly string[] m_schemaPaths = {
            "Assets/Zone/Scripts/Shared/Schemas/GameSettings.fbs",
            "Assets/Zone/Scripts/Shared/Schemas/Gameplay/PlayerSettings.fbs"
        };
        
        public string GetOutputDirectory()
        {
            return OUTPUT_DIRECTORY;
        }

        public IEnumerable<string> GetSchemaPaths()
        {
            return m_schemaPaths;
        }
    }
}
