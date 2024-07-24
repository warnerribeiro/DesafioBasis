using Domain.Model;

namespace Core.Repository
{
    public interface IBookRepository
    {
        Book? Get(int bookId);

        Book Add(Book book);

        Book Update(Book book);

        void Remove(int bookId);

        Task<IEnumerable<Book>> GetAsync();
    }
}
