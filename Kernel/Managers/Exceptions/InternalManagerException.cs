using System;

namespace Films.Kernel.Managers.Exceptions
{
    public class InternalManagerException: Exception
    {
        public InternalManagerException(string message): base(message) { }
    }
}
