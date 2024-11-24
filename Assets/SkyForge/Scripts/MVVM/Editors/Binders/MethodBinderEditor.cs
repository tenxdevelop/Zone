/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;

namespace SkyForge.Infrastructure.MVVM.Editors
{
    public abstract class MethodBinderEditor : BinderEditor
    {
        protected sealed override IEnumerable<string> GetPropertyNames()
        {
            return GetMethodNames();
        }

        protected abstract IEnumerable<string> GetMethodNames();
    }
}
