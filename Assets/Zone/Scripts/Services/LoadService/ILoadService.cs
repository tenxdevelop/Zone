/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;
using System;

namespace Zone.Services
{
    public interface ILoadService : IDisposable
    {
        TPrefab LoadPrefab<TPrefab>(string path) where TPrefab : UnityEngine.Object;
        TScriptableObject LoadScriptableObject<TScriptableObject>(string path) where TScriptableObject : ScriptableObject;

        byte[] LoadFlatBufferResource(string path);
    }
}
