using PrismApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Interfaces
{
    /// <summary>
    /// 处理歌词的服务
    /// </summary>
    public interface ILyricService
    {
        /// <summary>
        /// 读取歌词
        /// </summary>
        /// <param name="filePath">文件地址</param>
        /// <returns>歌词集合</returns>
        public ObservableCollection<LyricModel> ReadLyric(string filePath);
    }
}
