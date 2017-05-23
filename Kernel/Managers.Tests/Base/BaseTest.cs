using Films.Kernel.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Context.Tests.Base
{
    public class BaseTest
    {
        [TestInitialize]
        public void StartTest()
        {
            using (var context = new StorageContext())
            {
                context.Database.ExecuteSqlCommand("truncate table FilmActorBase");
                context.Films.RemoveRange(context.Films);
                context.Actors.RemoveRange(context.Actors);

                context.SaveChanges();
            }

            Start();
        }

        protected virtual void Start() { }
        protected void AssertCount<TDataType>(int count, IEnumerable<TDataType> list) => Assert.AreEqual(count, list.Count());
    }
}
