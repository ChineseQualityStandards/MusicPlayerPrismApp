using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Interfaces
{
    /// <summary>
    /// 专门处理时间格式的服务
    /// </summary>
    public interface ITimeFormatService
    {
        /// <summary>
        /// 获取当前时间的格式化字符串
        /// </summary>
        /// <returns>字符串</returns>
        public string GetTimeFormat();

        /// <summary>
        /// 时间戳转换为时-分-秒的格式
        /// </summary>
        /// <param name="timeSpan">传入时间</param>
        /// <returns>返回时-分-秒时间戳</returns>
        public TimeSpan TimeSpanClipping(TimeSpan timeSpan);

        /// <summary>
        /// 时间字段转换为时间戳
        /// </summary>
        /// <param name="timeString">传入字段</param>
        /// <returns>时间戳</returns>
        public TimeSpan TimeStringToTimeSpan(string timeString);
    }
}
