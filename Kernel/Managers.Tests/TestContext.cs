using Films.Kernel.Context;
using Films.Kernel.Managers.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Films.Kernel.Managers.Tests
{
    [TestClass]
    public class TestContext : BaseTest
    {
        [TestMethod]
        public void Context()
        {
            var countActors = Actors.GetAll().Count();
            var countFilms = Films.GetAll().Count();

            using (var context = new StorageContext())
            {
                var alex = context.Actors.Add(new Actor("Alexey", "Kirinyuk", new DateTime(1997, 02, 11)));
                Assert.IsNotNull(alex);
                countActors++;

                var yakov = context.Actors.Add(new Actor("Yakov", "Vins", new DateTime(1995, 01, 15)));
                Assert.IsNotNull(yakov);
                countActors++;

                context.SaveChanges();

                Assert.IsNotNull(context.Actors.Find(alex.Id));
                Assert.IsNotNull(context.Actors.Find(yakov.Id));
                AssertCount(countActors, context.Actors);

                var strage = context.Films.Add(new Film("Strage", "Russia", 5)
                {
                    Actors = new List<Actor>() { alex, yakov }
                });
                Assert.IsNotNull(strage);
                countFilms++;

                context.SaveChanges();

                Assert.IsNotNull(context.Films.Find(strage.Id));
                AssertCount(countActors, context.Actors);
                AssertCount(countFilms, context.Films);
            }
        }

    }
}
