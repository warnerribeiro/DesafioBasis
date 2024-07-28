using Domain.Model;

namespace Core.Repository
{
    public interface IAuthorRepository
    {
        Author? Get(int authorId);

        Task<Author> Add(Author author);

        Task<Author> Update(Author author);

        Task Remove(int authorId);

        Task<IEnumerable<Author>> GetAsync();
    }
}
