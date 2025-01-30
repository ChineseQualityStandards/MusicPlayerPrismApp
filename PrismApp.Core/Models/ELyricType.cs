using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Core.Models
{
    public enum ELyricType
    {
        /// <summary>
        /// title - 标题
        /// </summary>
        Ti = 0,
        /// <summary>
        /// artist - 艺术家
        /// </summary>
        Ar = 1,
        /// <summary>
        /// album - 专辑
        /// </summary>
        Al = 2,
        /// <summary>
        /// by - 制作
        /// </summary>
        By = 3,
        /// <summary>
        /// offset - 偏移
        /// </summary>
        Offset = 4,
        /// <summary>
        /// kana - 日文
        /// </summary>
        Kana = 5,
        /// <summary>
        /// lyric - 歌词
        /// </summary>
        Lyric = 6
    }
}
