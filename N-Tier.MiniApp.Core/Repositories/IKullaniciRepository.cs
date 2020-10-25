using N_Tier.MiniApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Core.Repositories
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        Task<IEnumerable<Kullanici>> GetAllWithAsync();
        Task<Kullanici> GetWithByIdAsync(int id);
    }
}
