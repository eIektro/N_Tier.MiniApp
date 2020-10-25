using N_Tier.MiniApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Core.Repositories
{
    public interface IGorevRepository : IRepository<Gorev>
    {
        Task<IEnumerable<Gorev>> GetAllWithAsync();
        Task<Gorev> GetWithByIdAsync(int id);
    }
}
