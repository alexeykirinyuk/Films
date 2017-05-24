namespace Films.Kernel.Managers
{
    public class ManagerFactory
    {
        #region Singletone
        private static object _locker = new object();
        private static ManagerFactory _instance;
        public static ManagerFactory Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (_locker)
                    {
                        if (null == _instance)
                        {
                            _instance = new ManagerFactory();
                        }
                    }
                }

                return _instance;
            }
        }
        #endregion

        public TManager Create<TManager>() where TManager : new()
        {
            return new TManager();
        }
    }
}
