using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _dataContext;
        private readonly IBookAutorRepository _bookAutorRepository;
        private readonly IBookSubjectRepository _bookSubjectRepository;
        private readonly IBookValueRepository _bookValueRepository;
        private readonly DbSet<Book> _dbSet;

        public BookRepository(DataContext datacontext, 
            IBookAutorRepository bookAutorRepository, 
            IBookSubjectRepository bookSubjectRepository, 
            IBookValueRepository bookValueRepository)
        {
            _dataContext = datacontext;
            _bookAutorRepository = bookAutorRepository;
            _bookSubjectRepository = bookSubjectRepository;
            _bookValueRepository = bookValueRepository;
            _dbSet = _dataContext.Book;
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Book?> Get(int bookId)
        {
            return await _dbSet
                .Include(a => a.BookAuthor)
                .Include(a => a.BookSubject)
                .Include(a => a.BookValue)
                .SingleAsync(a => a.BookId == bookId);
        }

        public async Task<Book> Add(Book book)
        {
            await _dbSet.AddAsync(book);
            await _dataContext.SaveChangesAsync();

            return book;
        }
        public async Task<Book> Update(Book book)
        {
            _dbSet.Update(book);
            await _dataContext.SaveChangesAsync();

            return book;
        }

        public async Task Remove(int bookId)
        {
            var book = await Get(bookId);

            if (book != null)
            {
                _dbSet.Remove(book);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
