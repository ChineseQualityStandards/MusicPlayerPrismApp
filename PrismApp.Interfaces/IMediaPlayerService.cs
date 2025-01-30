using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PrismApp.Interfaces
{
    public interface IMediaPlayerService
    {
        /// <summary>
        /// 创建一个音乐播放器
        /// </summary>
        /// <returns>音乐播放器</returns>
        public MediaElement Create();
        /// <summary>
        /// 播放器播放
        /// </summary>
        /// <param name="player">音乐播放器</param>
        public void Play(MediaElement player);
        /// <summary>
        /// 暂停播放
        /// </summary>
        /// <param name="player">音乐播放器</param>
        public void Pause(MediaElement player);
        /// <summary>
        /// 停止播放
        /// </summary>
        /// <param name="player">音乐播放器</param>
        public void Stop(MediaElement player);
        /// <summary>
        /// 调整音量
        /// </summary>
        /// <param name="player">音乐播放器</param>
        /// <param name="volume">音量大小</param>
        public void SetVolume(MediaElement player, double volume);
        /// <summary>
        /// 设置播放源
        /// </summary>
        /// <param name="player">音乐播放器</param>
        /// <param name="uri">播放源</param>
        public void SetSource(MediaElement player, Uri uri);
        /// <summary>
        /// 调整播放位置
        /// </summary>
        /// <param name="player">音乐播放器</param>
        /// <param name="timeSpan">时间戳</param>
        public void SetPosition(MediaElement player, TimeSpan position);
        /// <summary>
        /// 设置播放速度
        /// </summary>
        /// <param name="player">音乐播放器</param>
        /// <param name="speedRatio">播放速度</param>
        public void SetSpeedRatio(MediaElement player, double speedRatio);
        /// <summary>
        /// 设置播放平衡
        /// </summary>
        /// <param name="player">音乐播放器</param>
        /// <param name="balance">平衡度</param>
        public void SetBalance(MediaElement player, double balance);
        /// <summary>
        /// 设置是否静音
        /// </summary>
        /// <param name="player">音乐播放器</param>
        /// <param name="isMuted">是否静音</param>
        public void SetIsMuted(MediaElement player, bool isMuted);
        /// <summary>
        /// 获取播放位置
        /// </summary>
        /// <param name="player">音乐播放器</param>
        /// <returns>播放进度</returns>
        public TimeSpan GetPosition(MediaElement player);
        /// <summary>
        /// 获取音量
        /// </summary>
        /// <param name="player">音乐播放器</param>
        /// <returns>音量大小</returns>
        public double GetVolume(MediaElement player);
        /// <summary>
        /// 获取播放速度
        /// </summary>
        /// <param name="player">音乐播放器</param>
        /// <returns>播放速度</returns>
        public double GetSpeedRatio(MediaElement player);
        /// <summary>
        /// 获取播放平衡
        /// </summary>
        /// <param name="player">音乐播放器</param>
        /// <returns>播放平衡</returns>
        public double GetBalance(MediaElement player);
        /// <summary>
        /// 检查是否静音
        /// </summary>
        /// <param name="player">音乐播放器</param>
        /// <returns>静音/非静音</returns>
        public bool GetIsMuted(MediaElement player);
        /// <summary>
        /// 获取总时长
        /// </summary>
        /// <param name="player">音乐播放器</param>
        /// <returns>总时长</returns>
        public TimeSpan GetNaturalDuration(MediaElement player);
        /// <summary>
        /// 获取播放源
        /// </summary>
        /// <param name="player">音乐播放器</param>
        /// <returns>播放源</returns>
        public string GetSource(MediaElement player);
        /// <summary>
        /// 释放播放器
        /// </summary>
        /// <param name="player">音乐播放器</param>
        public void Dispose(MediaElement player);
    }
}
