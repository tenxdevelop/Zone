/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/


using SkyForge.Infrastructure.MVVM;
using SkyForge;

namespace Zone
{

    public class UIMainMenuRootViewModel : IUIMainMenuRootViewModel
    {
        [SubViewModel(typeof(UIMainMenuViewModel))]
        public IUIMainMenuViewModel UIMainMenuViewModel { get; private set; }

        public UIMainMenuRootViewModel(DIContainer container)
        {
            UIMainMenuViewModel = container.Resolve<IUIMainMenuViewModel>();
        }

        public void Dispose()
        {
            
        }
    }
}
