/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace Zone.Services
{
    public interface ILoadService : IDisposable
    {
        TPrefab LoadPrefab<TPrefab>(string path) where TPrefab : UnityEngine.Object;

    }
}
