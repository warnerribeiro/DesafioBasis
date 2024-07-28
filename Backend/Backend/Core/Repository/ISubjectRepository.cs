using Domain.Model;

namespace Core.Repository
{
    public interface ISubjectRepository
    {
        Subject Get(int sujectId);

        Task<Subject> Add(Subject subject);

        Task<Subject> Update(Subject subject);

        Task Remove(int sujectId);

        Task<IEnumerable<Subject>> GetAsync();
    }
}
