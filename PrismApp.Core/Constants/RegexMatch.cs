using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrismApp.Core.Constants
{
    /// <summary>
    /// 格式化字符串
    /// </summary>
    public class RegexMatch
    {
        /// <summary>
        /// 歌曲文件正则表达式
        /// </summary>
        public const string SONG_REGEX = "\\.(mp3|flac)$";
        /// <summary>
        /// 歌词正则表达式
        /// </summary>
        public const string LYRIC_REGEX = @"\[(\d{2}):(\d{2})\.(\d{2})\](.*)";
        /// <summary>
        /// 歌词元数据正则表达式
        /// </summary>
        public const string METADATA_REGEX = @"\[(\w+):(.+)\]";
        
    }
}
