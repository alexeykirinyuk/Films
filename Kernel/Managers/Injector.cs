using Films.Kernel.Managers.Logging;
using Films.Kernel.Managers.Storage;

namespace Films.Kernel.Managers
{
    public static class Injector
    {
        public static Configs Configs { get; } = new Configs();

        public static IStorageManager CreateStorageManager()
        {
            if (Configs.TurnDataBase)
            {
                return new StorageManager(CreateLog());
            }
            else
            {
                return new TestStorageManager();
            }
        }
        
        public static Log CreateLog()
        {
            return new Log(CreateLogger(), Configs.Debug);
        }
        private static ILogger CreateLogger()
        {
            if (Configs.TurnLog)
            {
                return new FileLogger(Configs.LogFileName);
            }
            else
            {
                return new TestLogger();
            }
        }
    }
}
