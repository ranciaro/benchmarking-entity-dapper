using PersistencePoc.Core.Entities;

namespace PersistencePoc.Infra.Dapper.Interfaces
{
    public interface IConcessionariaDapperRepository
    {
        Task<IEnumerable<Concessionaria>> GetAllAsync();
        Task<IEnumerable<Concessionaria>> GetAsync(int pageNumber, int pageSize);
    }
}
