using Films.Kernel.Context;
using System;

namespace Films.Kernel.Managers.Storage
{
    public interface IStorageManager
    {
        TResult WOperation<TResult>(string tag, string message, Func<StorageContext, TResult> action);
    }
}
