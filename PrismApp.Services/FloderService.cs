using PrismApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Services
{
    public class FloderService : IFloderService
    {
        public void CreatNewFloderIfIsInexistence(string floderName)
        {
            // 获取路径并判断
            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), floderName)))
            {
                // 创建目录
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), floderName));
            }
        }

        public string GetCurrentPath() => Directory.GetCurrentDirectory();
    }
}
