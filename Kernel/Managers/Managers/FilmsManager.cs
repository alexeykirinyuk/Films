using Films.Kernel.Context;
using Films.Kernel.Managers.Base;
using Films.Kernel.Managers.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Films.Kernel.Managers.Managers
{
    public class FilmsManager : BaseManager<Film>
    {
        public override string Tag => "Films";

        public static readonly string[] Includes = { "Actors" };

        public FilmsManager() : base() { }

        public override IEnumerable<Film> GetAll()
        {
            return _storage.WOperation(Tag, $"Get all films.", (context) =>
            {
                return context.Films.Includes(Includes).ToList();
            });
        }
        public override Film Find(long id)
        {
            return _storage.WOperation(Tag, $"Find film #{id}", (context) =>
            {
                return Find(context, id);
            });
        }

        public override Film Add(Film film)
        {
            return _storage.WOperation(Tag, $"Add film '{film.Name}'", (context) =>
            {
                UpdateActors(context, film, film.Actors);

                return context.Films.Add(film);
            });
        }
        public override Film Remove(long id)
        {
            return _storage.WOperation(Tag, $"Remove film #{id}.", (context) =>
            {
                var film = Find(context, id, true);

                //foreach (var actor in context.Actors)
                //{
                //    var entity = actor.Films.FirstOrDefault(f => f.Id == film.Id);

                //    if (null != entity)
                //    {
                //        actor.Films.Remove(entity);
                //    }
                //}

                return context.Films.Remove(film);
            });
        }
        public override Film Update(Film film)
        {
            return _storage.WOperation(Tag, $"Update film #{film.Id}", (context) =>
            {
                var entity = context.Films.Find(film.Id);

                entity.Update(film);
                UpdateActors(context, entity, film.Actors);

                return entity;
            });
        }

        private Film Find(StorageContext context, long id, bool notFoundException = false)
        {
            var film = context.Films.Includes(Includes).FirstOrDefault(f => f.Id == id);

            if (notFoundException && null == film)
            {
                throw new InternalManagerException($"Actor #{film.Id} not found.");
            }

            return film;
        }
        private Film UpdateActors(StorageContext context, Film film, IEnumerable<Actor> actors)
        {
            film.ClearActors();

            foreach (var actor in actors)
            {
                var entity = context.Actors.Find(actor.Id);

                if (null == entity)
                {
                    throw new InternalManagerException($"Film #{actor.Id} not found.");
                }

                film.Actors.Add(entity);
            }

            return film;
        }
    }
}
