using System;
using System.IO;

namespace OpenWeatherAPI.Logging
{
    public class FileLogger : IDisposable
    {
        public string LogFilePath { get; }
        private StreamWriter _streamWriter;
        private object _writerLock = new object();

        public FileLogger(string logFilePath)
        {
            LogFilePath = logFilePath;
            Init();
        }

        private void Init()
        {
            FileStream fileStream = File.Open(LogFilePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            _streamWriter = new StreamWriter(fileStream) { AutoFlush = true };
        }

        public void Log(string msg)
        {
            string formattedMsg = msg;
            WriteLine(formattedMsg);
        }

        private void WriteLine(string msg)
        {
            lock (_writerLock)
            {
                _streamWriter.WriteLine(msg);
            }
        }

        public void Dispose()
        {
            _streamWriter.Flush();
            _streamWriter.Dispose();
        }
    }
}
