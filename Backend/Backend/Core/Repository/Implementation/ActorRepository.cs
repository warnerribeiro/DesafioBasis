using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    internal class ActorRepository : IActorRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Actor> _dbSet;

        public ActorRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
            _dbSet = _dataContext.Actor;
        }

        public async Task<IEnumerable<Actor>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Actor? Get(int actorId)
        {
            return _dbSet.Find(actorId);
        }

        public Actor Add(Actor actor)
        {
            _dbSet.Add(actor);
            _dataContext.SaveChanges();

            return actor;
        }
        public Actor Update(Actor actor)
        {
            _dbSet.Update(actor);
            _dataContext.SaveChanges();

            return actor;
        }

        public void Remove(int actorId)
        {
            var actor = Get(actorId);

            if (actor != null)
            {
                _dbSet.Remove(actor);
                _dataContext.SaveChanges();
            }
        }
    }
}
