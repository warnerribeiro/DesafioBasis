using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    public class BookAuthorRepository : IBookAutorRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<BookAuthor> _dbSet;

        public BookAuthorRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
            _dbSet = _dataContext.BookAuthor;
        }

        public BookAuthor? Get(int bookAuthorId)
        {
            return _dbSet.Find(bookAuthorId);
        }

        public async Task<IEnumerable<BookAuthor>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<BookAuthor> Add(BookAuthor bookAuthor)
        {
            await _dbSet.AddAsync(bookAuthor);
            await _dataContext.SaveChangesAsync();

            return bookAuthor;
        }

        public async Task Add(IEnumerable<BookAuthor> bookAuthor)
        {
            await _dbSet.AddRangeAsync(bookAuthor);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<BookAuthor> Update(BookAuthor bookAuthor)
        {
            _dbSet.Update(bookAuthor);
            await _dataContext.SaveChangesAsync();

            return bookAuthor;
        }

        public async Task Remove(int bookAuthorId)
        {
            var bookAuthor = Get(bookAuthorId);

            await Remove(bookAuthor);
        }
        public async Task Remove(BookAuthor bookAuthor)
        {
            if (bookAuthor != null)
            {
                _dbSet.Remove(bookAuthor);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task Remove(IEnumerable<BookAuthor> bookAuthor)
        {
            _dbSet.RemoveRange(bookAuthor);
            await _dataContext.SaveChangesAsync();
        }
    }
}
