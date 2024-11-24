// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Zone
{

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct GameSettings : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_24_3_25(); }
  public static GameSettings GetRootAsGameSettings(ByteBuffer _bb) { return GetRootAsGameSettings(_bb, new GameSettings()); }
  public static GameSettings GetRootAsGameSettings(ByteBuffer _bb, GameSettings obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public static bool VerifyGameSettings(ByteBuffer _bb) {Google.FlatBuffers.Verifier verifier = new Google.FlatBuffers.Verifier(_bb); return verifier.VerifyBuffer("", false, GameSettingsVerify.Verify); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public GameSettings __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public Zone.Gameplay.PlayerSettings? PlayerSettings { get { int o = __p.__offset(4); return o != 0 ? (Zone.Gameplay.PlayerSettings?)(new Zone.Gameplay.PlayerSettings()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }

  public static Offset<Zone.GameSettings> CreateGameSettings(FlatBufferBuilder builder,
      Offset<Zone.Gameplay.PlayerSettings> PlayerSettingsOffset = default(Offset<Zone.Gameplay.PlayerSettings>)) {
    builder.StartTable(1);
    GameSettings.AddPlayerSettings(builder, PlayerSettingsOffset);
    return GameSettings.EndGameSettings(builder);
  }

  public static void StartGameSettings(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddPlayerSettings(FlatBufferBuilder builder, Offset<Zone.Gameplay.PlayerSettings> playerSettingsOffset) { builder.AddOffset(0, playerSettingsOffset.Value, 0); }
  public static Offset<Zone.GameSettings> EndGameSettings(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Zone.GameSettings>(o);
  }
  public static void FinishGameSettingsBuffer(FlatBufferBuilder builder, Offset<Zone.GameSettings> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedGameSettingsBuffer(FlatBufferBuilder builder, Offset<Zone.GameSettings> offset) { builder.FinishSizePrefixed(offset.Value); }
  public GameSettingsT UnPack() {
    var _o = new GameSettingsT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(GameSettingsT _o) {
    _o.PlayerSettings = this.PlayerSettings.HasValue ? this.PlayerSettings.Value.UnPack() : null;
  }
  public static Offset<Zone.GameSettings> Pack(FlatBufferBuilder builder, GameSettingsT _o) {
    if (_o == null) return default(Offset<Zone.GameSettings>);
    var _PlayerSettings = _o.PlayerSettings == null ? default(Offset<Zone.Gameplay.PlayerSettings>) : Zone.Gameplay.PlayerSettings.Pack(builder, _o.PlayerSettings);
    return CreateGameSettings(
      builder,
      _PlayerSettings);
  }
}

public class GameSettingsT
{
  public Zone.Gameplay.PlayerSettingsT PlayerSettings { get; set; }

  public GameSettingsT() {
    this.PlayerSettings = null;
  }
  public static GameSettingsT DeserializeFromBinary(byte[] fbBuffer) {
    return GameSettings.GetRootAsGameSettings(new ByteBuffer(fbBuffer)).UnPack();
  }
  public byte[] SerializeToBinary() {
    var fbb = new FlatBufferBuilder(0x10000);
    GameSettings.FinishGameSettingsBuffer(fbb, GameSettings.Pack(fbb, this));
    return fbb.DataBuffer.ToSizedArray();
  }
}


static public class GameSettingsVerify
{
  static public bool Verify(Google.FlatBuffers.Verifier verifier, uint tablePos)
  {
    return verifier.VerifyTableStart(tablePos)
      && verifier.VerifyTable(tablePos, 4 /*PlayerSettings*/, Zone.Gameplay.PlayerSettingsVerify.Verify, false)
      && verifier.VerifyTableEnd(tablePos);
  }
}

}