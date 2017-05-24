using Films.Kernel.Context;
using Films.Kernel.Managers.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Films.Kernel.Managers.Tests.Mangers
{
    [TestClass]
    public class TestActorsManager : BaseTest
    {
        [TestMethod]
        public void GetAll()
        {
            AssertCount(2, Actors.GetAll());

            Actors.Add(new Actor("new actor", "fn", DateTime.Now));
            AssertCount(3, Actors.GetAll());
        }

        [TestMethod]
        public void Find()
        {
            var id = Actor1.Id;
            var actor = Actors.Find(id);
            Assert.IsNotNull(actor);
            Assert.AreEqual(id, actor.Id);

            Assert.IsNotNull(actor.Films);
            AssertCount(2, actor.Films);

            //TODO: Write get outside id. #100 may be finded.
            Assert.IsNull(Actors.Find(100));
        }

        [TestMethod]
        public void Add()
        {
            var actor = new Actor("new actor", "fn", DateTime.Now);
            actor = Actors.Add(actor);

            AssertCount(3, Actors.GetAll());
            AssertCount(2, Films.GetAll());
            Assert.IsNotNull(actor);
            Assert.IsNotNull(Actors.Find(actor.Id));

            actor = new Actor("new actor", "fn", DateTime.Now);
            actor.Films.Add(Film1);
            actor.Films.Add(Film2);

            actor = Actors.Add(actor);

            AssertCount(4, Actors.GetAll());
            AssertCount(2, Films.GetAll());
            Assert.IsNotNull(actor);
            Assert.IsNotNull(Actors.Find(actor.Id));
        }

        [TestMethod]
        public void Remove()
        {
            var actor = Actors.Remove(Actor1.Id);
            Assert.IsNotNull(actor);

            Assert.IsNull(Actors.Find(Actor1.Id));
            AssertCount(1, Actors.GetAll());
            AssertCount(2, Films.GetAll());
        }

        [TestMethod]
        public void Update()
        {
            var name = "update";
            Actor1.FirstName = name;
            var actor = Actors.Update(Actor1);

            Assert.AreEqual(name, actor.FirstName);
            Assert.AreEqual(name, Actors.Find(actor.Id).FirstName);

            var film = new Film("new film", "Russia", 5);
            Films.Add(film);

            Actor1.Films.Add(film);
            var countFilms = Film1.Actors.Count;

            actor = Actors.Update(Actor1);

            AssertCount(countFilms, actor.Films);
            AssertCount(countFilms, Actors.Find(actor.Id).Films);
        }
    }
}

