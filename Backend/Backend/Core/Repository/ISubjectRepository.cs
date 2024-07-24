using Domain.Model;

namespace Core.Repository
{
    internal interface ISubjectRepository
    {
        Subject Get(int sujectId);

        Subject Add(Subject subject);

        Subject Update(Subject subject);

        void Remove(int sujectId);

        Task<IEnumerable<Subject>> GetAsync();
    }
}
