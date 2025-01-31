using PrismApp.Core.Constants;
using PrismApp.Core.Models;
using PrismApp.Core.Mvvm;
using PrismApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PrismApp.Views.Controller.ViewModels
{

    public class LyricViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager _regionManager;
        private readonly ILyricService _lyricService;
        private readonly ITimeFormatService _timeFormatService;

        #endregion

        #region 属性

        private int songID;

        public int SongID
        {
            get { return songID; }
            set { SetProperty(ref songID, value); }
        }

        private int lyricIndex;

        public int LyricIndex
        {
            get { return lyricIndex; }
            set { SetProperty(ref lyricIndex,value); }
        }

        

        private ObservableCollection<LyricModel>? lyrics;

        public ObservableCollection<LyricModel>? Lyrics
        {
            get { return lyrics; }
            set { SetProperty(ref lyrics, value); }
        }

        


        #endregion

        #region 命令

        #endregion

        #region 方法

        public LyricViewModel(IRegionManager regionManager,ILyricService lyricService, ITimeFormatService timeFormatService) : base(regionManager)
        {
            _regionManager = regionManager;
            _lyricService = lyricService;
            _timeFormatService = timeFormatService;
            if(GlobalVariable.Timer == null)
            {
                GlobalVariable.Timer = new DispatcherTimer();
                GlobalVariable.Timer.Interval = TimeSpan.FromSeconds(0.3);
            }
            Lyrics = new ObservableCollection<LyricModel>();

            GlobalVariable.Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (GlobalVariable.Timer != null)
            {
                if(SongID != GlobalVariable.CurrentPlayInfo.CurrentSongInfo.Id)
                {
                    SongID = GlobalVariable.CurrentPlayInfo.CurrentSongInfo.Id;
                    Lyrics = GlobalVariable.CurrentPlayInfo.CurrentSongInfo.Lyrics;
                }
                if (Lyrics != null)
                {
                    var lyric = Lyrics.Where(x => x.LyricTime <= GlobalVariable.CurrentPlayInfo.Playback).LastOrDefault();
                    if (lyric != null)
                    {
                        LyricIndex = lyric.Id;
                    }
                }
            }
        }
        #endregion
    }
}
