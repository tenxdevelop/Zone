/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge;

namespace Zone
{
    public static class MainMenuViewModelRegistration
    {
        public static void RegisterViewModel(DIContainer container)
        {
            container.RegisterSingleton<IUIMainMenuRootViewModel>(factory => new UIMainMenuRootViewModel(factory));
        }
    }
}
