using Films.Kernel.Context;
using Films.Kernel.Managers.Managers;
using Films.Server.Controllers;

namespace Films.Server.Views.Films
{
    public class ActorsController : BaseController<ActorsManager, Actor>
    {
        public override string Tag => "ActorsController";
    }
}