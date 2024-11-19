/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.MVVM;

namespace Zone
{
    public interface IUIMainMenuRootViewModel : IViewModel
    {
        IUIMainMenuViewModel UIMainMenuViewModel { get; }
    }
}
