using System;
using Films.Kernel.Context;

namespace Films.Kernel.Managers.Storage
{
    public class TestStorageManager : IStorageManager
    {
        public TResult WOperation<TResult>(string tag, string message, Func<StorageContext, TResult> action)
        {
            return default(TResult);
        }
    }
}
