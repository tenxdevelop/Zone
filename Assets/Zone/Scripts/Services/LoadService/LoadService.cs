/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace Zone.Services
{
    public class LoadService : ILoadService
    {
        public const string PREFAB_UI_ROOT = @"Prefabs\UI\UIRoot";
        public TPrefab LoadPrefab<TPrefab>(string path) where TPrefab : Object
        {
            var prefab = Resources.Load<TPrefab>(path);
            if (prefab is null)
            {
                Debug.LogError($"Can't load prefab from: {path}.");
                return null;
            }
            return prefab;
        }

        public void Dispose()
        {

        }
    }
}
