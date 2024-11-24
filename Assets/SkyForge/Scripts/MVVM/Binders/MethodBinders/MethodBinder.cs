/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Infrastructure.MVVM.Binders
{
    public abstract class MethodBinder : Binder
    {
        protected string MethodName => PropertyName;
    }
}
