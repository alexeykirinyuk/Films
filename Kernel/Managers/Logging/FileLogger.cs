using System;
using System.IO;
using System.Text;

namespace Films.Kernel.Managers.Logging
{
    public class FileLogger : ILogger
    {
        private static object _locker = new object();
        private string _fileName;

        public FileLogger(string fileName)
        {
            _fileName = fileName;
        }

        public void Write(string type, string tag, string message)
        {
            lock (_locker)
            {
                using (var stream = new StreamWriter(_fileName, true, Encoding.UTF8))
                {
                    stream.WriteLine($"[{type}] {DateTime.Now} ({tag}): {message}");
                }
            }
        }
    }
}
