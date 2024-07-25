using Domain.Model;

namespace Core.Repository
{
    public interface IAuthorRepository
    {
        Author? Get(int authorId);

        Author Add(Author author);

        Author Update(Author author);

        void Remove(int authorId);

        Task<IEnumerable<Author>> GetAsync();
    }
}
