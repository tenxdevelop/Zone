﻿/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using System;

namespace SkyForge.Infrastructure.MVVM.Binders
{
    public abstract class ObservableBinder : Binder
    {
        public abstract Type ArgumentType { get; }
    }

    public abstract class ObservableBinder<T> : ObservableBinder
    {
        public override Type ArgumentType => typeof(T);
        protected abstract void OnPropertyChanged(object sender, T newValue);
        protected override IBinding BindInternal(IViewModel viewModel)
        {
            return BindObservable(PropertyName, viewModel, OnPropertyChanged);
        }

        protected IBinding BindObservable(string propertyName, IViewModel viewModel, Action<T> callback)
        {
            var propertyInfo = viewModel.GetType().GetProperty(propertyName);
            var observable = propertyInfo.GetValue(viewModel) as Reactive.IObservable<T>;
            var handle = observable.Subscribe(callback);
            return handle;
        }

        protected IBinding BindObservable(string propertyName, IViewModel viewModel, Action<object, T> callback)
        {
            var propertyInfo = viewModel.GetType().GetProperty(propertyName);
            var observable = propertyInfo.GetValue(viewModel) as Reactive.IObservable<T>;
            var handle = observable.Subscribe(callback);
            return handle;
        }

        protected IBinding BindCollection(string propertyName, IViewModel viewModel, Action<T> actionAdded, Action<T> actionRemoved, Action actionClear)
        {
            var propertyInfo = viewModel.GetType().GetProperty(propertyName);
            var observable = propertyInfo.GetValue(viewModel) as IObservableCollection<T>;
            var handle = observable.Subscribe(actionAdded, actionRemoved, actionClear);
            return handle;
        }

        protected IBinding BindCollection(string propertyName, IViewModel viewModel, Action<object, T> actionAdded, Action<object, T> actionRemoved, Action<object> actionClear)
        {
            var propertyInfo = viewModel.GetType().GetProperty(propertyName);
            var observable = propertyInfo.GetValue(viewModel) as IObservableCollection<T>;
            var handle = observable.Subscribe(actionAdded, actionRemoved, actionClear);
            return handle;
        }
    }
}
