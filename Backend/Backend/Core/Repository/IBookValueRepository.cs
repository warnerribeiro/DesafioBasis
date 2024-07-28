using Domain.Model;

namespace Core.Repository
{
    public interface IBookValueRepository
    {
        Task<IEnumerable<BookValue>> GetAsync();

        BookValue? Get(int bookValueId);

        Task<BookValue> Add(BookValue bookValue);

        Task Add(IEnumerable<BookValue> bookValue);

        Task<BookValue> Update(BookValue bookValue);

        Task Remove(int bookValueId);

        Task Remove(BookValue bookValue);

        Task Remove(IEnumerable<BookValue> bookValue);
    }
}
