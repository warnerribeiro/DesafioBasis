using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    public class BookSubjectRepository : IBookSubjectRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<BookSubject> _dbSet;

        public BookSubjectRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
            _dbSet = _dataContext.BookSubject;
        }

        public async Task<BookSubject> Add(BookSubject bookSubject)
        {
            await _dbSet.AddAsync(bookSubject);
            await _dataContext.SaveChangesAsync();

            return bookSubject;
        }

        public async Task Add(IEnumerable<BookSubject> bookSubject)
        {
            await _dbSet.AddRangeAsync(bookSubject);
            await _dataContext.SaveChangesAsync();
        }

        public BookSubject? Get(int bookSubjectId)
        {
            return _dbSet.Find(bookSubjectId);
        }

        public async Task<IEnumerable<BookSubject>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Remove(int bookSubjectId)
        {
            var bookSubject = Get(bookSubjectId);

            await Remove(bookSubject);
        }

        public async Task Remove(IEnumerable<BookSubject> bookSubject)
        {
            _dbSet.RemoveRange(bookSubject);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Remove(BookSubject bookSubject)
        {
            if (bookSubject != null)
            {
                _dbSet.Remove(bookSubject);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<BookSubject> Update(BookSubject bookSubject)
        {
            _dbSet.Update(bookSubject);
            await _dataContext.SaveChangesAsync();

            return bookSubject;

        }
    }
}
