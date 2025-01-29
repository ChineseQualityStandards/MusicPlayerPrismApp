using PrismApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PrismApp.Services
{
    /// <summary>
    /// 音乐播放器服务
    /// </summary>
    public class MediaPlayerService : IMediaPlayerService
    {
        
        public MediaElement Create() => new MediaElement();
        
        public void Play(MediaElement player)
        {
            try
            {
                if (player != null)
                {
                    player.Play();
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void Pause(MediaElement player)
        {
            try
            {
                if (player != null)
                {
                    player.Pause();
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void Stop(MediaElement player)
        {
            try
            {
                if (player != null)
                {
                    player.Stop();
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void SetVolume(MediaElement player, double volume)
        {
            try
            {
                if (player != null)
                {
                    player.Volume = volume;
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void SetSource(MediaElement player, Uri uri)
        {
            try
            {
                if (player != null)
                {
                    player.Source = uri;
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void SetPosition(MediaElement player, TimeSpan timeSpan)
        {
            try
            {
                if (player != null)
                {
                    player.Position = timeSpan;
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void SetSpeedRatio(MediaElement player, double speedRatio)
        {
            try
            {
                if (player != null)
                {
                    player.SpeedRatio = speedRatio;
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void SetBalance(MediaElement player, double balance)
        {
            try
            {
                if (player != null)
                {
                    player.Balance = balance;
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void SetIsMuted(MediaElement player, bool isMuted)
        {
            try
            {
                if (player != null)
                {
                    player.IsMuted = isMuted;
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public TimeSpan GetPosition(MediaElement player)
        {
            try
            {
                if (player != null)
                {
                    return player.Position;
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public double GetVolume(MediaElement player)
        {
            try
            {
                if (player != null)
                {
                    return player.Volume;
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public double GetSpeedRatio(MediaElement player)
        {
            try
            {
                if (player != null)
                {
                    return player.SpeedRatio;
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public double GetBalance(MediaElement player)
        {
            try
            {
                if (player != null)
                {
                    return player.Balance;
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public bool GetIsMuted(MediaElement player)
        {
            try
            {
                if (player != null)
                {
                    return player.IsMuted;
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public TimeSpan GetNaturalDuration(MediaElement player)
        {
            try
            {
                if (player != null)
                {
                    return player.NaturalDuration.TimeSpan;
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public string GetSource(MediaElement player)
        {
            try
            {
                if (player != null)
                {
                    return player.Source.ToString();
                }
                else
                {
                    throw new ArgumentNullException("播放器不存在");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
