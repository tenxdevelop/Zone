/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;
using System.Threading.Tasks;

namespace Zone
{
    public interface ISettingsProvider : IDisposable
    {
        ApplicationSettings ApplicationSettings { get; }

        GameSettings GameSettings { get; }

        Task<GameSettings> LoadGameSettings();
    }
}
