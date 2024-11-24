/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.FlatBuffers;
using Google.FlatBuffers;

namespace Zone
{
    public class FlatBufferPacker : IFlatBufferPacker<GameSettings, GameSettingsT>
    {
        public GameSettings GetRootAsRootSettings(ByteBuffer buffer)
        {
            return GameSettings.GetRootAsGameSettings(buffer);
        }

        public Offset<GameSettings> Pack(FlatBufferBuilder builder, GameSettingsT settings)
        {
            return GameSettings.Pack(builder, settings);
        }

        public GameSettingsT UnPack(GameSettings mainSettings)
        {
            return mainSettings.UnPack();
        }
    }
}
