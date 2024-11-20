/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using UnityEngine;

namespace Zone
{
    public class PlayerStateProxy : IPlayerStateProxy
    {
        public ReactiveProperty<Vector3> Position { get; private set; }
        public PlayerState OriginState { get; private set; }

        public PlayerStateProxy(PlayerState playerState)
        {
            OriginState = playerState;
            Position = new ReactiveProperty<Vector3>(playerState.Position);

            Position.Subscribe(newValue => OriginState.Position = newValue);
        }
    }
}
