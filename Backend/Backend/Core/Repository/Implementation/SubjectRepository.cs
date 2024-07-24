using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    internal class SubjectRepository : ISubjectRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Subject> _dbSet;

        public SubjectRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
            _dbSet = _dataContext.Subject;
        }

        public async Task<IEnumerable<Subject>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Subject? Get(int subjectId)
        {
            return _dbSet.Find(subjectId);
        }

        public Subject Add(Subject subject)
        {
            _dbSet.Add(subject);
            _dataContext.SaveChanges();

            return subject;
        }
        public Subject Update(Subject subject)
        {
            _dbSet.Update(subject);
            _dataContext.SaveChanges();

            return subject;
        }

        public void Remove(int SubjectId)
        {
            var Subject = Get(SubjectId);

            if (Subject != null)
            {
                _dbSet.Remove(Subject);
                _dataContext.SaveChanges();
            }
        }
    }
}
