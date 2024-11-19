/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge;

namespace Zone
{
    public static class GameplayViewModelRegistration
    {
        public static void RegisterViewModel(DIContainer container)
        {
            container.RegisterSingleton<IUIGameplayRootViewModel>(factory => new UIGameplayRootViewModel(factory));
        }
    }
}
