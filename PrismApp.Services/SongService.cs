using NAudio.Wave;
using PrismApp.Core.Constants;
using PrismApp.Core.Models;
using PrismApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrismApp.Services
{
    public class SongService : ISongService
    {
        /// <summary>
        /// 从指定目录获取歌曲并匹配歌词
        /// </summary>
        /// <param name="dir">目录名</param>
        /// <returns>歌曲列表</returns>
        public ObservableCollection<SongModel> GetSongs(string dir)
        {
            int id = 0;
            var songs = new ObservableCollection<SongModel>();
            Regex regex = new Regex(RegexMatch.SONG_REGEX);
            var list = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories).Where(f => regex.IsMatch(Path.GetFileName(f))).ToList();
            foreach (var item in list)
            {
                songs.Add(new SongModel
                {
                    Id = id++,
                    Name = Path.GetFileNameWithoutExtension(item).Split('-').First(),
                    Singer = Path.GetFileNameWithoutExtension(item).Split('-').Last(),
                    LyricLink = Path.ChangeExtension(item, ".lrc"),
                    SongLink = item,
                    Status = EPlayType.Circulation,
                    TotalTime =new TimeFormatService().TimeSpanClipping(new AudioFileReader(item).TotalTime),
                    Metadata = new LyricService().GetMetadata(Path.ChangeExtension(item, ".lrc")),
                    Lyrics = new LyricService().ReadLyric(Path.ChangeExtension(item, ".lrc"))
                });
            }
            return songs;
        }
    }
}
