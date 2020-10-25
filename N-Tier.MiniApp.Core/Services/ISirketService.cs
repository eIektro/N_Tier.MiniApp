using N_Tier.MiniApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Core.Services
{
    public interface ISirketService
    {
        Task<IEnumerable<Sirket>> GetAllSirkets();
        Task<Sirket> GetSirketById(int id);
        Task<Sirket> CreateSirket(Sirket newSirket);
        Task UpdateSirket(Sirket sirketToBeUpdated, Sirket sirket);
        Task DeleteSirket(Sirket sirket);
    }
}
