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
        public TimeSpan playback;
        /// <summary>
        /// 已播放时长
        /// </summary>
        public TimeSpan Playback { get => playback; set => SetProperty(ref playback,value); }

        private double playSeconds;
        /// <summary>
        /// 已播放秒数
        /// </summary>
        public double PlaySeconds { get => playSeconds; set => SetProperty(ref playSeconds, value); }
        /// <summary>
        /// 当前播放歌曲的信息
        /// </summary>
        private SongModel? currentSongInfo;

        public SongModel? CurrentSongInfo
        {
            get { return currentSongInfo; }
            set { SetProperty(ref currentSongInfo, value); }
        }
        private double totalSeconds;
        /// <summary>
        /// 歌曲总秒数
        /// </summary>
        public double TotalSeconds { get => totalSeconds; set => SetProperty(ref totalSeconds,value); }
    }
}
