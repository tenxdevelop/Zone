/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.MVVM;

namespace Zone
{
    public interface IUIGameplayRootViewModel : IViewModel
    {
        IUIGameplayMenuViewModel GameplayMenuViewModel { get; }
    }
}
