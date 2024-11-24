/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;
using System;

namespace Zone.Services
{
    public class LoadService : ILoadService
    {
        public const string PREFAB_UI_ROOT = @"Prefabs\UI\UIRoot";
        public const string PREFAB_UI_MENU_ROOT = @"Prefabs\UI\Menu\UIMainMenuRoot";
        public const string PREFAB_UI_GAMEPLAY_ROOT = @"Prefabs\UI\Gameplay\UIGameplayRoot";


        public const string SRIPTABLE_OBJECT_APPLICATION_SETTINGS = @"Settings\ApplicationSettings";


        public const string FLATBUFFER_GAME_SETTINGS = @"Settings\" + ImportConstant.SETTINGS_FILE_NAME;

        public TPrefab LoadPrefab<TPrefab>(string path) where TPrefab : UnityEngine.Object
        {
            return LoadUnityObject<TPrefab>(path, pathObject => Debug.LogError($"Can't load prefab from: {pathObject}."));    
        }

        public TScriptableObject LoadScriptableObject<TScriptableObject>(string path) where TScriptableObject : ScriptableObject
        {
            return LoadUnityObject<TScriptableObject>(path, pathObject => Debug.LogError($"Can't load Sriptable object form: {pathObject}."));
        }

        public byte[] LoadFlatBufferResource(string path)
        {
            var textAsset = LoadUnityObject<TextAsset>(path, pathObject => Debug.LogError($"Can't load flatBuffer resouce settings from: {pathObject}."));

            if (textAsset is null)
                return null;

            return textAsset.bytes;
        }

        public void Dispose()
        {

        }

        private TObject LoadUnityObject<TObject>(string path, Action<string> errorCallBack = null) where TObject : UnityEngine.Object
        {
            var unityObject = Resources.Load<TObject>(path);

            if (unityObject is null)
            {
                if (errorCallBack is null)
                    Debug.LogError($"Can't load unity object from: {path}.");
                else
                    errorCallBack(path);
                return null;
            }
            return unityObject;
        }

        
    }
}
