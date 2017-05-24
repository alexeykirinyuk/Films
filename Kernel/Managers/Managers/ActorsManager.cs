using Films.Kernel.Context;
using Films.Kernel.Managers.Base;
using Films.Kernel.Managers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Films.Kernel.Managers.Managers
{
    public class ActorsManager : BaseManager<Actor>
    {
        public override string Tag => "Actors";

        public static readonly string[] Includes = { "Films" };

        public ActorsManager() : base() { }

        public override IEnumerable<Actor> GetAll()
        {
            return _storage.WOperation(Tag, "Get all actors.", (context) =>
            {
                return context.Actors.Includes(Includes).ToList();
            });
        }
        public override Actor Find(long id)
        {
            return _storage.WOperation(Tag, $"Find actor #{id}.", (context) =>
            {
                return Find(context, id);
            });
        }

        public override Actor Add(Actor actor)
        {
            return _storage.WOperation(Tag, $"Add new actor :{actor.FirstName}.", (context) =>
            {
                actor = UpdateFilms(context, actor);

                return context.Actors.Add(actor);
            });

        }

        public override Actor Remove(long id)
        {
            return _storage.WOperation(Tag, $"Remove actor #{id}.", (context) =>
            {
                var actor = Find(context, id, true);

                return context.Actors.Remove(actor);
            });
        }

        public override Actor Update(Actor actor)
        {
            return _storage.WOperation(Tag, $"Update actor #{actor.Id}.", (context) =>
            {
                var entity = Find(context, actor.Id, true);

                entity.Update(actor);
                actor = UpdateFilms(context, actor);

                return entity;
            });
        }

        private Actor Find(StorageContext context, long id, bool notFoundException = false)
        {
            var actor = context.Actors.Includes(Includes).FirstOrDefault(a => a.Id == id);

            if (notFoundException && null == actor)
            {
                throw new InternalManagerException($"Actor #{actor.Id} not found.");
            }

            return actor;
        }
        private Actor UpdateFilms(StorageContext context, Actor actor)
        {
            var films = actor.Films;
            actor.ClearFilms();

            foreach (var film in films)
            {
                var entityFilm = context.Films.Find(film.Id);

                if (null == entityFilm)
                {
                    throw new InternalManagerException($"Film #{film.Id} not found.");
                }

                actor.Films.Add(entityFilm);
            }

            return actor;
        }
    }
}
