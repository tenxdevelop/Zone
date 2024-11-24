/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Infrastructure.Reactive
{
    public interface IReactiveProperty<out T> : IObservable<T>
    {
        T Value { get; }  
    }
}
