/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Infrastructure.Proxy
{
    public interface IProxy
    {

    }

    public interface IProxy<TEntityState> : IProxy
    {
        TEntityState OriginState { get; }
    }
}
