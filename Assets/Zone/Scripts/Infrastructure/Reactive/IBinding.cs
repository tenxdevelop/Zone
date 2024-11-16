/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.Infrastructure.Reactive
{
    public interface IBinding : IDisposable
    {
        void Binded();
    }
}
