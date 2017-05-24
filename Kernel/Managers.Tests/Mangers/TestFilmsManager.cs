using Films.Kernel.Context;
using Films.Kernel.Managers.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Films.Kernel.Managers.Tests
{
    [TestClass]
    public class TestFilmsManager : BaseTest
    {
        [TestMethod]
        public void GetAll()
        {
            AssertCount(2, Films.GetAll());

            Films.Add(new Film("new film", "Russia", 10));
            AssertCount(3, Films.GetAll());
        }

        [TestMethod]
        public void Find()
        {
            var id = Film1.Id;
            var film = Films.Find(id);
            Assert.IsNotNull(film);
            Assert.AreEqual(id, film.Id);

            Assert.IsNotNull(film.Actors);
            AssertCount(2, film.Actors);

            //TODO: Write get outside id. #100 may be finded.
            Assert.IsNull(Films.Find(100));
        }

        [TestMethod]
        public void Add()
        {
            var film = new Film("film3", "Russia", 10);
            film = Films.Add(film);

            AssertCount(3, Films.GetAll());
            AssertCount(2, Actors.GetAll());
            Assert.IsNotNull(film);
            Assert.IsNotNull(Films.Find(film.Id));

            film = new Film("film4", "Russia", 10);
            film.Actors.Add(Actor1);
            film.Actors.Add(Actor2);
            film = Films.Add(film);

            AssertCount(4, Films.GetAll());
            AssertCount(2, Actors.GetAll());
            Assert.IsNotNull(film);
            Assert.IsNotNull(Films.Find(film.Id));
        }

        [TestMethod]
        public void Remove()
        {
            var film = Films.Remove(Film1.Id);
            Assert.IsNotNull(film);

            Assert.IsNull(Films.Find(Film1.Id));
            AssertCount(1, Films.GetAll());
            AssertCount(2, Actors.GetAll());
        }

        [TestMethod]
        public void Update()
        {
            var name = "update";
            Film1.Name = name;
            var film = Films.Update(Film1);

            Assert.AreEqual(name, film.Name);
            Assert.AreEqual(name, Films.Find(film.Id).Name);

            var actor = new Actor("new actor", "fam", DateTime.Now);
            Actors.Add(actor);

            Film1.Actors.Add(actor);
            var countActors = Film1.Actors.Count;

            film = Films.Update(Film1);

            AssertCount(countActors, film.Actors);
            AssertCount(countActors, Films.Find(film.Id).Actors);
        }
    }
}
