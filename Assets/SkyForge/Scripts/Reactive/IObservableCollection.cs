/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Infrastructure.Reactive
{
    public interface IObservableCollection<T>
    {
        IBinding Subscribe(IObserverCollection<T> observer);
        void Unsubscribe(IObserverCollection<T> observer);
    }
}
