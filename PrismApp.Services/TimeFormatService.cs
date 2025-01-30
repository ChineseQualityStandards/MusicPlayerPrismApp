using PrismApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Services
{
    
    public class TimeFormatService : ITimeFormatService
    {
        public string GetTimeFormat() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public TimeSpan TimeSpanClipping(TimeSpan timeSpan) => new TimeSpan(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

        public TimeSpan TimeStringToTimeSpan(string timeString)
        {
            string[] timeArray = timeString.Split(':');
            if (timeArray.Length != 3)
            {
                throw new ArgumentException("时间格式不正确");
            }
            return new TimeSpan(int.Parse(timeArray[0]), int.Parse(timeArray[1]), int.Parse(timeArray[2]));
        }
    }
}
