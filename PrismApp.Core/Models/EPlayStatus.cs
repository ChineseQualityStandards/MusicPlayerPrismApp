using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Core.Models
{
    /// <summary>
    /// (歌曲)播放状态
    /// </summary>
    public enum EPlayStatus
    {
        /// <summary>
        /// 已暂停
        /// </summary>
        Paused = 728799,
        /// <summary>
        /// 播放中
        /// </summary>
        Playing = 7529464,
        /// <summary>
        /// 停止
        /// </summary>
        Stopped = 7867733,
    }
}
