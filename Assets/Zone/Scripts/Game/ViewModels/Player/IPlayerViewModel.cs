/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using SkyForge.Infrastructure.MVVM;
using UnityEngine;

namespace Zone
{
    public interface IPlayerViewModel : IViewModel
    {
        ReactiveProperty<Vector3> Position { get; }
        void Move(Vector3 direction);
    }
}
