using Microsoft.EntityFrameworkCore;
using N_Tier.MiniApp.Core.Models;
using N_Tier.MiniApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Data.Repositories
{
    public class SirketRepository : Repository<Sirket>, ISirketRepository
    {
        public SirketRepository(MiniAppDbContext context) : base(context)
        {

        }

        private MiniAppDbContext MiniAppDbContext
        {
            get { return context as MiniAppDbContext; }
        }

        public async Task<IEnumerable<Sirket>> GetAllWithAsync()
        {
            return await MiniAppDbContext.Sirket.ToListAsync();
        }

        public Task<Sirket> GetWithByIdAsync(int id)
        {
            return MiniAppDbContext.Sirket.SingleOrDefaultAsync(i => i.Id == id);
        }
    }
}
