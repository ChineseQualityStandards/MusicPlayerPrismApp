using PrismApp.Core.Models;
using PrismApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
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
                // 读取文件
                else
                {
                    var collection = new ObservableCollection<LyricModel>();
                    int id = 0;
                    using (var reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // 跳过空行
                            if (string.IsNullOrEmpty(line))
                            {
                                continue;
                            }
                            // 定义歌词模型
                            var lyric = new LyricModel();
                            // 获取]的位置
                            var index = line.IndexOf("]");
                            // 如果没有找到"]"则跳过
                            if (index == -1)
                            {
                                continue;
                            }
                            // 截取行头
                            var head = line.Substring(1, index - 1);
                            // 判断是否为歌词
                            if (TimeSpan.TryParse(head, out var timeSpan))
                            {
                                lyric.Id = id++;
                                lyric.LyricTime = timeSpan;
                                lyric.Lyric = line.Substring(index + 1);
                                lyric.LyricType = ELyricType.Lyric;
                                collection.Add(lyric);
                            }
                            // 如果不是歌词则为其他信息
                            else
                            {
                                lyric.Id = id++;
                                lyric.LyricTime = TimeSpan.Zero;
                                lyric.Lyric = head.Split(':')[1];
                                lyric.LyricType = head.Split(':')[0] switch
                                {
                                    "ti" => ELyricType.Ti,
                                    "ar" => ELyricType.Ar,
                                    "al" => ELyricType.Al,
                                    "by" => ELyricType.By,
                                    "offset" => ELyricType.Offset,
                                    "kana" => ELyricType.Kana,
                                    _ => ELyricType.Lyric
                                };
                            }
                        }
                    }
                    return collection;
                }
                
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
