/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using System;
using UnityEngine;

namespace Zone
{
    public interface IPlayerService : IDisposable
    {
        IReactiveProperty<IPlayerViewModel> PlayerViewModel { get; }
        bool MovePlayer(Vector3 direction, float speed);
    }
}
