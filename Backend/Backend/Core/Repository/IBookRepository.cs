using Domain.Model;

namespace Core.Repository
{
    public interface IBookRepository
    {
        Task<Book?> Get(int bookId);

        Task<Book> Add(Book book);

        Task<Book> Update(Book book);

        Task Remove(int bookId);

        Task<IEnumerable<Book>> GetAsync();
    }
}
