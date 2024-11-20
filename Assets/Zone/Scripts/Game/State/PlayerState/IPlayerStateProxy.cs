/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using SkyForge.Infrastructure.Proxy;
using UnityEngine;

namespace Zone
{
    public interface IPlayerStateProxy : IProxy<PlayerState>
    {
        ReactiveProperty<Vector3> Position { get; }
    }
}
