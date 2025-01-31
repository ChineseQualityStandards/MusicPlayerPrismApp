using PrismApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PrismApp.Core.Constants
{
    /// <summary>
    /// 全局变量
    /// </summary>
    public class GlobalVariable : BindableBase
    {
        #region 文件夹

        // 获取系统默认的Musics文件夹

        public static string? FolderPath { get; private set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        /// <summary>
        /// 如果文件夹不存在则创建
        /// </summary>
        public static void CreateFolder()
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
        }
        /// <summary>
        /// 更新文件夹路径
        /// </summary>
        /// <param name="path">传入路径</param>
        /// <exception cref="DirectoryNotFoundException">找不到文件夹时报错</exception>
        public static void SetFolderPath(string path) => FolderPath = Directory.Exists(path) ? path : throw new DirectoryNotFoundException("路径有误");

        /// <summary>
        /// 判断文件夹是否存在，不存在则创建
        /// </summary>
        public static void IsMusicFolderHas()
        {
            if (!Directory.Exists(FolderPath))
            {
                SetFolderPath(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            }
        }

        #endregion

        #region 播放器

        public static MediaElement? MusicPlayer { get; set; } = new MediaElement() { UnloadedBehavior = MediaState.Manual };

        public static ObservableCollection<SongModel> Songs { get; private set; } = new ObservableCollection<SongModel>();
        /// <summary>
        /// 加载歌曲
        /// </summary>
        /// <param name="songs">需要传入的歌曲列表</param>
        public static void LoadSongs(ObservableCollection<SongModel> songs) => Songs = songs != null ? songs : new ObservableCollection<SongModel>();

        public static CurrentPlayInfo CurrentPlayInfo { get; set; } = new CurrentPlayInfo();

        #endregion

        #region 计时器

        public static int TickIndex { get; set; } = 0;

        public static DispatcherTimer? Timer { get; set; } = new DispatcherTimer();

        #endregion
    }
}
