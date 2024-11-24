/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;

namespace SkyForge.Infrastructure.Proxy
{
    public interface IStateProvider<TProxy> : System.IDisposable where TProxy : IProxy
    {
        TProxy ProxyState { get; }

        IObservable<bool> SaveState();

        IObservable<bool> ResetState();

        IObservable<TProxy> LoadState();
    }
}
