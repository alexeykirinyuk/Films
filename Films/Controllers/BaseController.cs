using Films.Kernel.Context;
using Films.Kernel.Managers;
using Films.Kernel.Managers.Base;
using Films.Kernel.Managers.Logging;
using System;
using System.Web.Mvc;

namespace Films.Server.Controllers
{
    public abstract class BaseController<TManager, TDataType> : Controller where TManager : BaseManager<TDataType>, new() where TDataType : BaseModel, new()
    {
        public abstract string Tag { get; }

        protected ManagerFactory _factory;
        protected BaseManager<TDataType> _manager;
        protected Log _log;

        public BaseController() : this(Injector.CreateLog())
        {
            _factory = ManagerFactory.Instance;
            _manager = _factory.Create<TManager>();
        }
        public BaseController(Log log)
        {
            _log = log;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return WViewRequest($"Get all elements.", () =>
            {
                return View(_manager.GetAll());
            });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return WViewRequest($"Create new element.", () =>
            {
                var element = new TDataType();
                element = _manager.Add(element);

                return View(element);
            });
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            return WViewRequest($"Edit element #{id}.", () =>
            {
                var model = Find("Edit", id);

                return View(model);
            });
        }

        [HttpGet]
        public ActionResult Details(long id)
        {
            return WViewRequest($"Details for element #{id}.", () =>
            {
                var model = Find("Details", id);

                return View(model);
            });
        }

        [HttpGet]
        public ActionResult Remove(long id)
        {
            return WViewRequest($"Remove element #{id}", () =>
            {
                _manager.Remove(id);

                return RedirectIndex();
            });
        }
        [HttpGet]
        public ActionResult Update(TDataType element)
        {
            return WViewRequest($"Update element #{element.Id}", () =>
            {
                Find("Update", element.Id);
                _manager.Update(element);

                return RedirectIndex();
            });
        }

        protected TDataType Find(string action, long id)
        {
            var model = _manager.Find(id);

            if (null == model)
            {
                throw new InvalidRequestException($"{action}: element with same id#{id} not found");
            }

            return model;
        }
        protected ActionResult WViewRequest(string message, Func<ActionResult> action)
        {
            var result = default(ActionResult);

            try
            {
                result = action();

                _log.Info(Tag, message);
            }
            catch (InvalidRequestException exception)
            {
                _log.Error(Tag, exception);

                return RedirectToAction("NotFound");
            }

            return result;
        }
        protected ActionResult RedirectIndex()
        {
            return RedirectToAction("Index");
        }
    }
}