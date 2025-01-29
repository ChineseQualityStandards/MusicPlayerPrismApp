using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Core.Models
{
    /// <summary>
    /// 播放模式
    /// </summary>
    public enum EPlayType
    {
        /// <summary>
        /// 顺序播放(不循环)
        /// </summary>
        Order = 67337,
        /// <summary>
        /// 随机播放
        /// </summary>
        Suffle = 783353,
        /// <summary>
        /// 单曲循环
        /// </summary>
        Single = 746453,
        /// <summary>
        /// 列表循环
        /// </summary>
        Circulation = 247285283,
    }
}
