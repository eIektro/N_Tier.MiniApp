using N_Tier.MiniApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Core.Services
{
    public interface IGorevService
    {
        Task<IEnumerable<Gorev>> GetAllGorevs();
        Task<Gorev> GetGorevById(int id);
        Task<Gorev> CreateGorev(Gorev newGorev);
        Task UpdateGorev(Gorev gorevToBeUpdated, Gorev gorev);
        Task DeleteGorev(Gorev gorev);
    }
}
