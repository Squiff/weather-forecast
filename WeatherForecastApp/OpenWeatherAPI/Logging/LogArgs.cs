using System;

namespace OpenWeatherAPI.Logging
{
    /// <summary>
    /// Log Details passed in the Log event
    /// </summary>
    public class LogArgs
    {
        public DateTime DateTime {get; set;}
        public string Message { get; set; }

        public LogArgs(string message)
        {
            Message = message;
            DateTime = DateTime.Now;
        }

        public string FormatMessage()
        {
            var dte = DateTime.ToString("yyyy-MM-dd HH:mm:SS.fff").PadRight(30);
            return dte + Message;
        }
    }
}
