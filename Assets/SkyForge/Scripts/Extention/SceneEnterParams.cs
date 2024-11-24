/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge
{
    public abstract class SceneEnterParams
    {
        public T As<T>() where T : SceneEnterParams
        {
            return (T)this;
        }
    }
}
