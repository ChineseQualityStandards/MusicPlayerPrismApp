using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Core.Models
{
    public class LyricModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 歌词
        /// </summary>
        public string? Lyric { get; set; }
        /// <summary>
        /// 对应时间
        /// </summary>
        public TimeSpan LyricTime { get; set; }
    }
}
