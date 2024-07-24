using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Book> _dbSet;

        public BookRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
            _dbSet = _dataContext.Book;
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Book? Get(int bookId)
        {
            return _dbSet.Find(bookId);
        }

        public Book Add(Book book)
        {
            _dbSet.Add(book);
            _dataContext.SaveChanges();

            return book;
        }
        public Book Update(Book book)
        {
            _dbSet.Update(book);
            _dataContext.SaveChanges();

            return book;
        }

        public void Remove(int bookId)
        {
            var book = Get(bookId);

            if (book != null)
            {
                _dbSet.Remove(book);
                _dataContext.SaveChanges();
            }
        }
    }
}
