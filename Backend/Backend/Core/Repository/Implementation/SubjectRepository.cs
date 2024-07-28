using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    public class SubjectRepository : ISubjectRepository
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

        public async Task<Subject> Add(Subject subject)
        {
            await _dbSet.AddAsync(subject);
            await _dataContext.SaveChangesAsync();

            return subject;
        }
        public async Task<Subject> Update(Subject subject)
        {
            _dbSet.Update(subject);
            await _dataContext.SaveChangesAsync();

            return subject;
        }

        public async Task Remove(int SubjectId)
        {
            var Subject = Get(SubjectId);

            if (Subject != null)
            {
                _dbSet.Remove(Subject);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
