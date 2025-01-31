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
    /// 歌曲服务接口
    /// </summary>
    public interface ISongService
    {
        /// <summary>
        /// 通过指定文件夹获取歌曲列表
        /// </summary>
        /// <param name="dir">文件夹链接</param>
        /// <returns>歌曲列表</returns>
        public ObservableCollection<SongModel> GetSongs(string dir);
    }
}
