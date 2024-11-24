/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace Zone
{
    [CreateAssetMenu(fileName = "ApplicationSettings", menuName ="Zone/Settings/New Application Settings")]
    public class ApplicationSettings : ScriptableObject
    {
        public int MaxFPS;
    }
}
