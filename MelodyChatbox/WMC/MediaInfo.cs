using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelodyChatbox.WMC
{
    internal class MediaInfo
    {
        public static string Artist { get; set; } = string.Empty;
        public static string Track { get; set; } = string.Empty;
        public static TimeSpan StartTime { get; set; }
        public static TimeSpan CurTime { get; set; }
        public static TimeSpan EndTime { get; set; }
        public static TimeSpan TOTALTIME { get; set; }
    }
}
