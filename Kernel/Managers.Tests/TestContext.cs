using Context.Tests.Base;
using Films.Kernel.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Context.Tests
{
    [TestClass]
    public class TestContext : BaseTest
    {
        [TestMethod]
        public void Context()
        {
            using (var context = new StorageContext())
            {
                var alex = context.Actors.Add(new Actor("Alexey", "Kirinyuk", new DateTime(1997, 02, 11)));
                Assert.IsNotNull(alex);

                var yakov = context.Actors.Add(new Actor("Yakov", "Vins", new DateTime(1995, 01, 15)));
                Assert.IsNotNull(yakov);

                context.SaveChanges();

                Assert.IsNotNull(context.Actors.Find(alex.Id));
                Assert.IsNotNull(context.Actors.Find(yakov.Id));
                AssertCount(2, context.Actors);

                var strage = context.Films.Add(new Film("Strage", "Russia", 5)
                {
                    Actors = new List<Actor>() { alex, yakov }
                });
                Assert.IsNotNull(strage);

                context.SaveChanges();

                Assert.IsNotNull(context.Films.Find(strage.Id));
                AssertCount(2, context.Actors);
                AssertCount(1, context.Films);
            }
        }

    }
}
