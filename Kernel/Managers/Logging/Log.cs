using System;

namespace Films.Kernel.Managers.Logging
{
    public class Log
    {
        private ILogger _logger;
        private bool _debug;

        public Log(ILogger logger, bool debug)
        {
            _logger = logger;
            _debug = debug;
        }

        public void Info(string tag, string message) => _logger.Write("Info", tag, message);
        public void Warning(string tag, string message) => _logger.Write("Warning", tag, message);
        public void Error(string tag, Exception exception)
        {
            _logger.Write("Error", tag, exception.Message);

            if (_debug)
            {
                throw exception;
            }
        }
    }
}
