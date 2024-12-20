/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.MVVM;

namespace Zone
{
    public interface IUIRootViewModel : IViewModel
    {
        void ShowLoadingScreen();
        void HideLoadingScreen();
        void AttachSceneUIStatic(UIView sceneUIStatic, bool newScene);
        void AttachSceneUIDynamic(UIView sceneUIDynamic, bool newScene);
    }
}
