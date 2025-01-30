using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Core.Models
{
    /// <summary>
    /// 当前播放信息信息
    /// </summary>
    public class CurrentPlayInfo : BindableBase
    {
        /// <summary>
        /// 后一句歌词
        /// </summary>
        public string? LyricAfter { set; get; }
        /// <summary>
        /// 前一句歌词
        /// </summary>
        public string? LyricBefore { get; set; }
        /// <summary>
        /// 已播放时长
        /// </summary>
        public TimeSpan Playback { get; set; }
        /// <summary>
        /// 已播放秒数
        /// </summary>
        public double PlaySeconds { get; set; }
        /// <summary>
        /// 当前播放歌曲的序号
        /// </summary>
        public int SongId {  get; set; }
        /// <summary>
        /// 当前播放歌名
        /// </summary>
        public string? SongName { get; set; }
        /// <summary>
        /// 歌曲总秒数
        /// </summary>
        public double TotalSeconds { get; set; }
        /// <summary>
        /// 歌曲总时长
        /// </summary>
        public TimeSpan TotalTime { get; set; }
    }
}
