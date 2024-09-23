using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PersistencePoc.Core.Entities;
using PersistencePoc.Infra.EntityFrameworkSix.Context;
using PersistencePoc.Infra.EntityFrameworkSix.Interfaces;

namespace PersistencePoc.Infra.EntityFrameworkSix.Repositories
{
    public class ConcessionariaEntityRepository : IConcessionariaEntityRepository, IDisposable
    {
        private readonly DatabaseContext _context;
        private bool _disposed = false;

        public ConcessionariaEntityRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Concessionaria>> GetAsync()
        {
            _context.Configuration.AutoDetectChangesEnabled = false;
            _context.Configuration.LazyLoadingEnabled = false;
            _context.Configuration.ProxyCreationEnabled = false;

            using (var transaction = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
            {
                var concessionarias = await _context.Concessionarias!.AsNoTracking()
                                                                     .OrderBy(c => c.Id)
                                                                     .ToListAsync();

                transaction.Commit();
                return concessionarias;
            }
        }


        public async Task<IEnumerable<Concessionaria>> GetAllAsync()
        {
            var retorno = await _context.Concessionarias.ToListAsync();

            return retorno;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }

        ~ConcessionariaEntityRepository()
        {
            Dispose(false);
        }
    }
}

