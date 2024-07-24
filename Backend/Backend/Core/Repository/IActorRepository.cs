using Domain.Model;

namespace Core.Repository
{
    internal interface IActorRepository
    {
        Actor? Get(int actorId);

        Actor Add(Actor actor);

        Actor Update(Actor actor);

        void Remove(int actorId);

        Task<IEnumerable<Actor>> GetAsync();
    }
}
