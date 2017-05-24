using Films.Kernel.Context;
using Films.Kernel.Managers.Logging;
using System;

namespace Films.Kernel.Managers.Storage
{
    public class StorageManager : IStorageManager
    {
        private Log _log;

        public StorageManager(Log log)
        {
            _log = log;
        }

        public TResult WOperation<TResult>(string tag, string message, Func<StorageContext, TResult> action)
        {
            var result = default(TResult);

            using (var context = new StorageContext())
            {
                try
                {
                    result = action(context);
                    context.SaveChanges();

                    _log.Info(tag, message);
                }
                catch (Exception exception)
                {
                    _log.Error(tag, exception);
                }
            }

            return result;
        }
    }
}
