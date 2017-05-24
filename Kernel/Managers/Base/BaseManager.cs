using Films.Kernel.Managers.Logging;
using Films.Kernel.Managers.Storage;
using System.Collections.Generic;

namespace Films.Kernel.Managers.Base
{
    public abstract class BaseManager<TDataType> where TDataType: new()
    {
        public abstract string Tag { get; }

        public abstract IEnumerable<TDataType> GetAll();
        public abstract TDataType Find(long id);

        public abstract TDataType Add(TDataType element);
        public abstract TDataType Update(TDataType element);
        public abstract TDataType Remove(long id);

        protected IStorageManager _storage;

        public BaseManager() : this(Injector.CreateStorageManager()) { }
        public BaseManager(IStorageManager storage)
        {
            _storage = storage;
        }
    }
}