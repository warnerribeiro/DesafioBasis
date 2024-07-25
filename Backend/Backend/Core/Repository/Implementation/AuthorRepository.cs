using Backend.Model;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<Author> _dbSet;

        public AuthorRepository(DataContext datacontext)
        {
            _dataContext = datacontext;
            _dbSet = _dataContext.Author;
        }

        public async Task<IEnumerable<Author>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Author? Get(int authorId)
        {
            return _dbSet.Find(authorId);
        }

        public Author Add(Author author)
        {
            _dbSet.Add(author);
            _dataContext.SaveChanges();

            return author;
        }
        public Author Update(Author author)
        {
            _dbSet.Update(author);
            _dataContext.SaveChanges();

            return author;
        }

        public void Remove(int authorId)
        {
            var author = Get(authorId);

            if (author != null)
            {
                _dbSet.Remove(author);
                _dataContext.SaveChanges();
            }
        }
    }
}
