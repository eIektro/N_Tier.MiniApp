using N_Tier.MiniApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Core.Repositories
{
    public interface ISirketRepository : IRepository<Sirket>
    {
        Task<IEnumerable<Sirket>> GetAllWithAsync();
        Task<Sirket> GetWithByIdAsync(int id);
    }
}
