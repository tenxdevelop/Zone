﻿/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using UnityEngine;
using System;

namespace SkyForge.Infrastructure.MVVM.Binders
{
    public abstract class GenericMethodBinder : MethodBinder
    {
        public abstract Type ArgumentType { get; }
    }

    public class GenericMethodBinder<T> : GenericMethodBinder
    {
        public override Type ArgumentType => typeof(T);

        protected Action<object, T> m_action;
        protected override IBinding BindInternal(IViewModel viewModel)
        {
            m_action = Delegate.CreateDelegate(typeof(Action<object, T>), viewModel, MethodName) as Action<object, T>;
            OnBind();
            return null;
        }
        protected virtual void OnBind() { }
        public void Perform(T newValue)
        {
            m_action?.Invoke(null, newValue);
        }

        public void Perform(Component sender, T newValue)
        {
            m_action?.Invoke(sender, newValue);
        }
    }

    
}
