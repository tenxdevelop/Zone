/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.Infrastructure
{
    public abstract class DIEntry : IDisposable
    {
        protected DIContainer m_container { get; private set; }
        public DIEntry(DIContainer container)
        {
            m_container = container;
        }
        public T CreateFactory<T>()  where T : IDisposable
        {
            return ((DIEntry<T>)this).CreateFactory();
        }

        public void Dispose()
        {
            Disposed();
        }

        protected virtual void Disposed() 
        {
            m_container = null;
        }
    }

    public abstract class DIEntry<T> : DIEntry  where T : IDisposable
    {
        protected Func<DIContainer, T> m_factory { get; }
        public DIEntry(DIContainer container, Func<DIContainer, T> factory) : base(container)
        {
            m_factory = factory;
        }
        public abstract T CreateFactory();
    }
}
