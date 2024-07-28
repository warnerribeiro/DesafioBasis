using Domain.Model;

namespace Core.Repository
{
    public interface IBookAutorRepository
    {
        Task<IEnumerable<BookAuthor>> GetAsync();

        BookAuthor? Get(int bookAuthorId);

        Task<BookAuthor> Add(BookAuthor bookAuthor);

        Task Add(IEnumerable<BookAuthor> bookAuthor);

        Task<BookAuthor> Update(BookAuthor bookAuthor);

        Task Remove(int bookAuthorId);

        Task Remove(BookAuthor bookAuthor);

        Task Remove(IEnumerable<BookAuthor> bookAuthor);
    }
}
