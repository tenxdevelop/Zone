/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace SkyForge.Infrastructure.MVVM
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SubViewModelAttribute : Attribute
    {
        public Type AcctualType { get; private set; }
        public SubViewModelAttribute(Type acctualType)
        {
            AcctualType = acctualType;
        }
    }
}
