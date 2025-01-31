using PrismApp.Core.Constants;
using PrismApp.Core.Models;
using PrismApp.Core.Mvvm;
using PrismApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismApp.Views.Controller.ViewModels
{

    public class PlayerViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager _regionManager;
        private readonly ILyricService _lyricService;
        private readonly IMediaPlayerService _playerService;
        private readonly ISongService _songService;
        private readonly ITimeFormatService _timeFormatService;

        #endregion

        #region 属性

        private ButtonProperty showLyricButton;
        /// <summary>
        /// 歌词页面按钮
        /// </summary>
        public ButtonProperty ShowLyricButton
        {
            get { return showLyricButton; }
            set { SetProperty(ref showLyricButton, value); }
        }

        private ButtonProperty playModeButton;
        /// <summary>
        /// 歌曲播放模式按钮
        /// </summary>
        public ButtonProperty PlayModeButton
        {
            get { return playModeButton; }
            set { SetProperty(ref playModeButton, value); }
        }

        private ButtonProperty previousButton;
        /// <summary>
        /// 上一首按钮
        /// </summary>
        public ButtonProperty PreviousButton
        {
            get { return previousButton; }
            set { SetProperty(ref previousButton, value); }
        }

        private ButtonProperty playOrPauseButton;
        /// <summary>
        /// 歌曲播放/暂停按钮
        /// </summary>
        public ButtonProperty PlayOrPauseButton
        {
            get { return playOrPauseButton; }
            set { SetProperty(ref playOrPauseButton, value); }
        }

        private ButtonProperty nextButton;
        /// <summary>
        /// 下一首按钮
        /// </summary>
        public ButtonProperty NextButton
        {
            get { return nextButton; }
            set { SetProperty(ref nextButton, value); }
        }

        private ButtonProperty volumeButton;
        /// <summary>
        /// 音量按钮
        /// </summary>
        public ButtonProperty VolumeButton
        {
            get { return volumeButton; }
            set { SetProperty(ref volumeButton, value); }
        }

        private ObservableCollection<SongModel> songs;
        /// <summary>
        /// 存放歌曲的集合
        /// </summary>
        public ObservableCollection<SongModel> Songs
        {
            get { return songs; }
            set { SetProperty(ref songs, value); }
        }

        private CurrentPlayInfo playInfo;
        /// <summary>
        /// 当前播放信息
        /// </summary>
        public CurrentPlayInfo PlayInfo
        {
            get { return playInfo; }
            set { SetProperty(ref playInfo, value); }
        }

        private int songIndex;
        /// <summary>
        /// 当前播放歌曲的索引
        /// </summary>
        public int SongIndex
        {
            get { return songIndex; }
            set { SetProperty(ref songIndex, value); }
        }

        private double volume = 0.5;

        public double Volume
        {
            get { return volume; }
            set
            {
                SetProperty(ref volume, value);
                _playerService.SetVolume(GlobalVariable.MusicPlayer, volume);
            }
        }

        #endregion

        #region 命令

        public DelegateCommand<string> DelegateCommand { get; set; }

        #endregion

        #region 方法

        public PlayerViewModel(IRegionManager regionManager,ILyricService lyricService, IMediaPlayerService playerService, ISongService songService, ITimeFormatService timeFormatService) : base(regionManager)
        {
            _regionManager = regionManager;
            _lyricService = lyricService;
            _playerService = playerService;
            _songService = songService;
            _timeFormatService = timeFormatService;

            GlobalVariable.IsMusicFolderHas();

            GlobalVariable.LoadSongs(_songService.GetSongs(GlobalVariable.FolderPath));

            Songs = GlobalVariable.Songs;

            PlayInfo = GlobalVariable.CurrentPlayInfo;

            #region 按钮属性

            ShowLyricButton = new ButtonProperty
            {
                Icon = new IconProperty("Music", 47, 47),
                Type = EButtonType.Lyrics,
                TypeName = EButtonType.Lyrics.ToString(),
                ToolTip = "歌词"
            };

            PlayModeButton = new ButtonProperty
            {
                Icon = new IconProperty("RepeatVariant", 30, 30),
                Type = EButtonType.Circulation,
                TypeName = EButtonType.Circulation.ToString(),
                ToolTip = "列表循环",
            };

            PreviousButton = new ButtonProperty
            {
                Icon = new IconProperty("SkipPrevious", 30, 30),
                Type = EButtonType.Previous,
                TypeName = EButtonType.Previous.ToString(),
                ToolTip = "上一首"
            };

            PlayOrPauseButton = new ButtonProperty
            {
                Icon = new IconProperty("Play", 30, 30),
                Type = EButtonType.Play,
                TypeName = EButtonType.Play.ToString(),
                ToolTip = "播放"
            };

            NextButton = new ButtonProperty
            {
                Icon = new IconProperty("SkipNext", 30, 30),
                Type = EButtonType.Next,
                TypeName = EButtonType.Next.ToString(),
                ToolTip = "下一首"
            };

            VolumeButton = new ButtonProperty
            {
                Icon = new IconProperty("VolumeHigh", 30, 30),
                Type = EButtonType.Volume,
                TypeName = EButtonType.Volume.ToString(),
                ToolTip = "音量"
            };
            #endregion

            #region 播放信息

            PlayInfo = new CurrentPlayInfo
            {
                CurrentSongInfo = new SongModel
                {
                    Id = -1,
                    Name = "--",
                    Singer = "--",
                    LyricLink = "--",
                    SongLink = "--",
                    Status = EPlayType.Suffle,
                    TotalTime = TimeSpan.Zero,
                },
                LyricAfter = "前面的歌词",
                LyricBefore = "后面的歌词",
                Playback = TimeSpan.Zero,
                PlaySeconds = 0,
                TotalSeconds = 0
            };

            SongIndex = 0;

            //Player = GlobalVariable.MusicPlayer;

            #endregion

            DelegateCommand = new DelegateCommand<string>(DelegateMethod);
            // 播放器计时器
            GlobalVariable.Timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// 更新播放器计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            PlayInfo.Playback = _timeFormatService.TimeSpanClipping(GlobalVariable.MusicPlayer.Position);
            PlayInfo.PlaySeconds = (int)PlayInfo.Playback.TotalSeconds; 
            GlobalVariable.CurrentPlayInfo = PlayInfo;
        }

        private void DelegateMethod(string type)
        {
            switch (type)
            {
                case "Lyrics":
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.LyricView);
                    break;
                case "Suffle":
                    PlayModeButton = new ButtonProperty
                    {
                        Icon = new IconProperty("RepeatVariant", 30, 30),
                        Type = EButtonType.Circulation,
                        TypeName = EButtonType.Circulation.ToString(),
                        ToolTip = "列表循环"
                    };
                    break;
                case "Circulation":
                    PlayModeButton = new ButtonProperty
                    {
                        Icon = new IconProperty("RepeatOnce", 30, 30),
                        Type = EButtonType.Single,
                        TypeName = EButtonType.Single.ToString(),
                        ToolTip = "单曲循环"
                    };
                    break;
                case "Single":
                    PlayModeButton = new ButtonProperty
                    {
                        Icon = new IconProperty("ShuffleVariant", 30, 30),
                        Type = EButtonType.Suffle,
                        TypeName = EButtonType.Suffle.ToString(),
                        ToolTip = "随机播放"
                    };
                    break;
                case "Previous":
                    try
                    {
                        ToPrevious();
                        PlayOrPauseButton = new ButtonProperty
                        {
                            Icon = new IconProperty("Pause", 30, 30),
                            Type = EButtonType.Pause,
                            TypeName = EButtonType.Pause.ToString(),
                            ToolTip = "暂停"
                        };
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;
                case "Play":
                    try
                    {
                        Playing();
                        PlayOrPauseButton = new ButtonProperty
                        {
                            Icon = new IconProperty("Pause", 30, 30),
                            Type = EButtonType.Pause,
                            TypeName = EButtonType.Pause.ToString(),
                            ToolTip = "暂停"
                        };
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;

                case "Pause":
                    try
                    {
                        Pausing();
                        PlayOrPauseButton = new ButtonProperty
                        {
                            Icon = new IconProperty("Play", 30, 30),
                            Type = EButtonType.Play,
                            TypeName = EButtonType.Play.ToString(),
                            ToolTip = "播放"
                        };
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;
                case "Next":
                    try
                    {
                        ToNext();
                        PlayOrPauseButton = new ButtonProperty
                        {
                            Icon = new IconProperty("Pause", 30, 30),
                            Type = EButtonType.Pause,
                            TypeName = EButtonType.Pause.ToString(),
                            ToolTip = "暂停"
                        };
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    break;
                default:
                    MessageBox.Show(type);
                    break;
            }
        }

        

        /// <summary>
        /// 上一首歌曲
        /// </summary>
        private void ToPrevious()
        {
            switch (PlayModeButton.Type)
            {
                case EButtonType.Suffle:
                    SongIndex = new Random().Next(0, Songs.Count);
                    break;
                case EButtonType.Circulation:
                    SongIndex = PlayInfo.CurrentSongInfo.Id == 0 ? Songs.Count - 1 : PlayInfo.CurrentSongInfo.Id - 1;
                    break;
                case EButtonType.Single:
                    SongIndex = PlayInfo.CurrentSongInfo.Id;
                    break;
                default:
                    break;
            }
            if(GlobalVariable.Timer != null)
            {
                GlobalVariable.Timer.Stop();
            }
            Play();
        }
        
        public void Play()
        {
            PlayInfo.CurrentSongInfo = Songs[SongIndex];
            PlayInfo.TotalSeconds = PlayInfo.CurrentSongInfo.TotalTime.TotalSeconds;
            _playerService.SetSource(GlobalVariable.MusicPlayer, new Uri(PlayInfo.CurrentSongInfo.SongLink));
            GlobalVariable.CurrentPlayInfo = PlayInfo;
            _playerService.Play(GlobalVariable.MusicPlayer);
            if (GlobalVariable.Timer != null)
            {
                GlobalVariable.Timer.Start();
            }
        }

        /// <summary>
        /// 播放音乐
        /// </summary>
        public void Playing()
        {
            try
            {
                if (SongIndex != PlayInfo.CurrentSongInfo.Id)
                {
                    Play();
                }
                else
                {
                    _playerService.Play(GlobalVariable.MusicPlayer);
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        /// <summary>
        /// 暂停音乐
        /// </summary>
        private void Pausing()
        {
            try
            {
                if (GlobalVariable.MusicPlayer.CanPause)
                {
                    _playerService.Pause(GlobalVariable.MusicPlayer);
                    if (GlobalVariable.Timer != null)
                    {
                        GlobalVariable.Timer.Stop();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 下一首歌曲
        /// </summary>
        private void ToNext()
        {
            switch(PlayModeButton.Type)
            {
                case EButtonType.Suffle:
                    SongIndex = new Random().Next(0, Songs.Count);
                    break;
                case EButtonType.Circulation:
                    SongIndex = PlayInfo.CurrentSongInfo.Id == Songs.Count - 1 ? 0 : PlayInfo.CurrentSongInfo.Id + 1;
                    break;
                case EButtonType.Single:
                    SongIndex = PlayInfo.CurrentSongInfo.Id;
                    break;
                default:
                    break;
            }
            if (GlobalVariable.Timer != null)
            {
                GlobalVariable.Timer.Stop();
            }
            Play();
        }

        #endregion
    }
}

