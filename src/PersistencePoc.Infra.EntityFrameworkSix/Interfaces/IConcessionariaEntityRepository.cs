using PersistencePoc.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistencePoc.Infra.EntityFrameworkSix.Interfaces
{
    public interface IConcessionariaEntityRepository
    {
        Task<IEnumerable<Concessionaria>> GetAllAsync();
        Task<IEnumerable<Concessionaria>> GetAsync();
    }
}
