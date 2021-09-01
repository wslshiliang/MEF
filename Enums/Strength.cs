using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    /// <summary>
    /// 密码强度
    /// </summary>
    public enum Strength
    {
        /// <summary>
        /// 无效密码
        /// </summary>
        Invalid = 0,
        /// <summary>
        /// 低强度密码
        /// </summary>
        Weak = 1,
        /// <summary>
        /// 中强度密码
        /// </summary>
        Normal = 2,
        /// <summary>
        /// 高强度密码
        /// </summary>
        Strong = 3
    };
}
