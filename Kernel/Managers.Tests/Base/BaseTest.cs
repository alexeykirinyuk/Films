using Films.Kernel.Context;
using Films.Kernel.Managers.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Films.Kernel.Managers.Tests.Base
{
    public class BaseTest
    {
        protected FilmsManager Films { get; }
        protected ActorsManager Actors { get; }

        protected Film Film1 { get; }
        protected Film Film2 { get; }

        protected Actor Actor1 { get; }
        protected Actor Actor2 { get; }

        public BaseTest()
        {
            Injector.Configs.Debug = true;
            Injector.Configs.TurnDataBase = true;
            Injector.Configs.TurnLog = false;

            Films = ManagerFactory.Instance.Create<FilmsManager>();
            Actors = ManagerFactory.Instance.Create<ActorsManager>();

            Actor1 = new Actor("fn1", "ln1", new DateTime(1985, 02, 11));
            Actor2 = new Actor("fn2", "ln2", new DateTime(1984, 02, 11));

            Film1 = new Film("film example1", "Russia", 5);
            Film2 = new Film("film example2", "USA", 10);

            Film1.Actors.Add(Actor1);
            Film1.Actors.Add(Actor2);

            Film2.Actors.Add(Actor1);
            Film2.Actors.Add(Actor2);
        }

        [TestInitialize]
        public void StartTest()
        {
            using (var context = new StorageContext())
            {
                context.Database.ExecuteSqlCommand("truncate table FilmActorBase");
                context.Films.RemoveRange(context.Films);
                context.Actors.RemoveRange(context.Actors);

                context.SaveChanges();

                context.Actors.Add(Actor1);
                context.Actors.Add(Actor2);

                context.SaveChanges();

                context.Films.Add(Film1);
                context.Films.Add(Film2);

                context.SaveChanges();
            }

            Start();
        }

        protected virtual void Start() { }
        protected void AssertCount<TDataType>(int count, IEnumerable<TDataType> list) => Assert.AreEqual(count, list.Count());
    }
}
