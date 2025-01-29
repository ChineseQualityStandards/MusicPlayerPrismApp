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
        public string GetTimeFormat()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public TimeSpan TimeSpanClipping(TimeSpan timeSpan) => new TimeSpan(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
    }
}
