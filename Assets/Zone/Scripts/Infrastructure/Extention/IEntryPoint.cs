/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using System.Collections;

namespace SkyForge
{
    public interface IEntryPoint
    {
        IEnumerator Intialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams);
        IObservable<SceneExitParams> Run();
    }
}
