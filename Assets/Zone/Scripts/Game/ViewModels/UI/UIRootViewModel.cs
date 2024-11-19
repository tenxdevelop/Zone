/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.MVVM;
using SkyForge.Infrastructure.Reactive;

namespace Zone
{
    public class UIRootViewModel : IUIRootViewModel
    {
        public ReactiveProperty<bool> IsOpenLoadingScreen { get; private set; } = new();

        public ReactiveCollection<View> UIStaticContainer { get; private set; } = new();
        public ReactiveCollection<View> UIDynamicContainer { get; private set; } = new();

        public void AttachSceneUIDynamic(UIView sceneUIDynamic, bool newScene)
        {
            if(newScene)
                UIDynamicContainer.Clear();

            UIDynamicContainer.Add(sceneUIDynamic);
        }

        public void AttachSceneUIStatic(UIView sceneUIStatic, bool newScenee)
        {
            if (newScenee)
                UIStaticContainer.Clear();

            UIStaticContainer.Add(sceneUIStatic);
        }

        public void Dispose()
        {
            
        }

        public void HideLoadingScreen()
        {
            IsOpenLoadingScreen.SetValue(null, false);
        }

        public void ShowLoadingScreen()
        {
            IsOpenLoadingScreen.SetValue(null, true);
        }
    }
}
