using System;

namespace Films.Kernel.Managers.Logging
{
    public interface ILogger
    {
        void Write(string type, string tag, string message);
    }
}
