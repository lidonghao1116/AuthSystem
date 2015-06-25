using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthSystem.AuthModel
{
    /// <summary>
    /// 基础AuthModel类
    /// </summary>
    [Serializable]
    public class AMBase:IDisposable
    {
        public AMBase()
        {
            //TODO:初始化
        }
        public virtual void Dispose()
        {
            //
        }
    }
}
