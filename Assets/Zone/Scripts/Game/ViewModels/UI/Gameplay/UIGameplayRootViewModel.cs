/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge;
using SkyForge.Infrastructure.MVVM;

namespace Zone
{
    public class UIGameplayRootViewModel : IUIGameplayRootViewModel
    {
        [SubViewModel(typeof(UIGameplayMenuViewModel))]
        public IUIGameplayMenuViewModel GameplayMenuViewModel { get; private set; }

        public UIGameplayRootViewModel(DIContainer container)
        {
            GameplayMenuViewModel = container.Resolve<IUIGameplayMenuViewModel>();
        }

        public void Dispose()
        {
            
        }
    }
}
