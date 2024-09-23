using Dapper;
using Microsoft.Extensions.Caching.Memory;
using PersistencePoc.Core.Entities;
using PersistencePoc.Infra.Dapper.Context;
using PersistencePoc.Infra.Dapper.Interfaces;
using System.Data;

namespace PersistencePoc.Infra.Dapper.Repositories
{
    public class ConcessionariaDapperRepository : IConcessionariaDapperRepository, IDisposable
    {
        private readonly DatabaseContext _context;
        private readonly IMemoryCache _cache;
        private bool _disposed = false;

        public ConcessionariaDapperRepository(DatabaseContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IEnumerable<Concessionaria>> GetAsync(int pageNumber, int pageSize)
        {
            string cacheKey = $"Concessionarias_Page_{pageNumber}_Size_{pageSize}";
            IEnumerable<Concessionaria>? concessionarias;

            if (_cache.TryGetValue(cacheKey, out concessionarias))
            {
                return concessionarias!;
            }

            IDbConnection dbConnection = _context.CreateConnection();
            try
            {
                int offset = (pageNumber - 1) * pageSize;
                string sqlQuery = "SELECT * FROM Concessionaria (NOLOCK) ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                var parameters = new { Offset = offset, PageSize = pageSize };
                concessionarias = await dbConnection.QueryAsync<Concessionaria>(sqlQuery, parameters);

                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                    SlidingExpiration = TimeSpan.FromMinutes(30)
                };

                _cache.Set(cacheKey, concessionarias, cacheOptions);

                return concessionarias!;
            }
            finally
            {
                if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
                {
                    dbConnection.Close();
                }
            }
        }

        public async Task<IEnumerable<Concessionaria>> GetAllAsync()
        {
            IDbConnection dbConnection = _context.CreateConnection();
            try
            {
                string sqlQuery = "SELECT * FROM Concessionaria (NOLOCK) ORDER BY Id";

                IEnumerable<Concessionaria> concessionarias = await dbConnection.QueryAsync<Concessionaria>(sqlQuery);

                return concessionarias!;
            }
            finally
            {
                if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
                {
                    dbConnection.Close();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.Collect();
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        ~ConcessionariaDapperRepository()
        {
            Dispose(false);
        }
    }
}
