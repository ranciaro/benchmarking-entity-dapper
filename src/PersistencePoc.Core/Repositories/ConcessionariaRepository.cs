using Dapper;
using PersistencePoc.Core.Context;
using PersistencePoc.Core.Entities;
using PersistencePoc.Core.Interfaces;
using System.Data;

namespace PersistencePoc.Core.Repositories
{
    public class ConcessionariaRepository : IConcessionariaRepository
    {
        private readonly DatabaseContext _context;

        public ConcessionariaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Concessionaria>> GetUsersAsync()
        {
            using (IDbConnection dbConnection = _context.CreateConnection())
            {
                string sqlQuery = "SELECT * FROM Concessionaria";
                return await dbConnection.QueryAsync<Concessionaria>(sqlQuery);
            }
        }
    }
}
