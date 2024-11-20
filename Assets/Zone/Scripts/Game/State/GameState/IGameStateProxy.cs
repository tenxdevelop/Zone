/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Proxy;
using SkyForge.Infrastructure.Reactive;

namespace Zone
{
    public interface IGameStateProxy : IProxy<GameState>
    {
        ReactiveProperty<PlayerStateProxy> PlayerState { get; }
    }
}
