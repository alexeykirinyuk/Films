using Films.Kernel.Context;
using Films.Kernel.Managers.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Films.Server.Controllers
{
    public class FilmsController : BaseController<FilmsManager, Film>
    {
        public override string Tag => "FilmsController";
        private ActorsManager _actors;

        public FilmsController() : base()
        {
            _actors = _factory.Create<ActorsManager>();
        }

        public override ActionResult Create()
        {
            ViewBag.AllActors = _actors.GetAll();

            return base.Create();
        }
        public override ActionResult Edit(long id)
        {
            ViewBag.AllActors = _actors.GetAll();

            return base.Edit(id);
        }
        public override ActionResult Update(Film element)
        {
            if (null != element.ActorIds)
            {
                element.Actors = _actors.GetAll().Where(a => element.ActorIds.Contains(a.Id)).ToList();
            }
            else
            {
                element.Actors = new List<Actor>();
            }

            return base.Update(element);
        }
    }
}