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
    public class LyricService : ILyricService
    {
        public ObservableCollection<LyricModel> ReadLyric(string filePath)
        {
			try
			{
                // 判断文件地址是否为空
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentNullException("文件地址为空");
                }
                // 判断文件是否存在
                else if (!File.Exists(filePath))
                {
                    throw new ArgumentException("文件不存在");
                }
                ObservableCollection<LyricModel> lyrics = new ObservableCollection<LyricModel>();
                int id = 0;
                // 读取文件
                var lyricRegex = new Regex(RegexMatch.LYRIC_REGEX);
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var match = lyricRegex.Match(line);
                    if (match.Success)
                    {
                        // 歌词
                        var minutes = int.Parse(match.Groups[1].Value);
                        var seconds = int.Parse(match.Groups[2].Value);
                        var milliseconds = int.Parse(match.Groups[3].Value);
                        var lyric = match.Groups[4].Value;
                        var time = new TimeSpan(0, 0, minutes, seconds, milliseconds);
                        lyrics.Add(new LyricModel
                        {
                            Id = id++,
                            Lyric = lyric,
                            LyricTime = time
                        });
                    }
                }
                return lyrics;

            }
			catch (Exception)
			{

				throw;
			}
        }

        public LyricMetadata GetMetadata(string filePath)
        {
            try
            {
                // 判断文件地址是否为空
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentNullException("文件地址为空");
                }
                // 判断文件是否存在
                else if (!File.Exists(filePath))
                {
                    throw new ArgumentException("文件不存在");
                }
                var metadata = new LyricMetadata();
                // 读取文件
                var metadaRegex = new Regex(RegexMatch.METADATA_REGEX);
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var match = metadaRegex.Match(line);
                    if (match.Success)
                    {
                        var key = match.Groups[1].Value.ToLower();
                        var value = match.Groups[2].Value;
                        switch (key)
                        {
                            case "ti":
                                metadata.Title = value;
                                break;
                            case "ar":
                                metadata.Artist = value;
                                break;
                            case "al":
                                metadata.Album = value;
                                break;
                            case "by":
                                metadata.By = value;
                                break;
                            case "offset":
                                metadata.Offset = int.Parse(value);
                                break;
                        }
                    }
                }
                return metadata;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


    

}
