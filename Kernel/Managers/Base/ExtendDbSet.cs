using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Films.Kernel.Managers.Base
{
    public static class ExtendDbSet
    {
        public static IEnumerable<TDataType> Includes<TDataType>(this DbSet<TDataType> dbSet, params string[] includes) where TDataType : class
        {
            var result = dbSet as DbQuery<TDataType>;

            foreach (var include in includes)
            {
                result = result.Include(include);
            }

            return result;
        }
    }
}
