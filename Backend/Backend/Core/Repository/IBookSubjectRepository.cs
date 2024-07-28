using Domain.Model;

namespace Core.Repository
{
    public interface IBookSubjectRepository
    {
        Task<IEnumerable<BookSubject>> GetAsync();

        BookSubject? Get(int bookSubjectId);

        Task<BookSubject> Add(BookSubject bookSubject);

        Task Add(IEnumerable<BookSubject> bookSubject);

        Task<BookSubject> Update(BookSubject bookSubject);

        Task Remove(int bookSubjectId);

        Task Remove(BookSubject bookSubject);

        Task Remove(IEnumerable<BookSubject> bookSubject);
    }
}
