using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Core.Models
{
    /// <summary>
    /// 歌曲所包含的信息
    /// </summary>
    public class SongModel : BindableBase
    {
        /// <summary>
        /// 歌曲排序序号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 歌名
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 歌手
        /// </summary>
        public string? Singer { get; set; }
        /// <summary>
        /// 歌词地址
        /// </summary>
        public string? LyricLink { get; set; }
        /// <summary>
        /// 歌曲地址
        /// </summary>
        public string? SongLink { get; set; }
        /// <summary>
        /// 播放状态
        /// </summary>
        public EPlayType? Status { get; set; }
        /// <summary>
        /// 歌曲时长
        /// </summary>
        public TimeSpan TotalTime { get; set; }

        public LyricMetadata? Metadata { get; set; }

        /// <summary>
        /// 歌词
        /// </summary>
        public ObservableCollection<LyricModel>? Lyrics { get; set; }
    }
}
