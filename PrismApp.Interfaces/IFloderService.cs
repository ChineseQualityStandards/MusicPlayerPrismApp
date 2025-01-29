using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Interfaces
{
    /// <summary>
    /// 处理文件夹的服务
    /// </summary>
    public interface IFloderService
    {
        /// <summary>
        /// 检查文件夹是否存在，不存在则创建
        /// </summary>
        /// <param name="floderName">需要创建的文件夹名</param>
        public void CreatNewFloderIfIsInexistence(string floderName);

        /// <summary>
        /// 获取当前路径
        /// </summary>
        /// <returns>当前文件夹字符串</returns>
        public string GetCurrentPath();
    }
}
