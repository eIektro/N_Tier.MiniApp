using Microsoft.EntityFrameworkCore;
using N_Tier.MiniApp.Core.Models;
using N_Tier.MiniApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Data.Repositories
{
    public class GorevRepository : Repository<Gorev>, IGorevRepository
    {
        public GorevRepository(MiniAppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Gorev>> GetAllWithAsync()
        {
            return await MiniAppDbContext.Gorev
                .ToListAsync();
        }

        public Task<Gorev> GetWithByIdAsync(int id)
        {
            return MiniAppDbContext.Gorev.SingleOrDefaultAsync(i => i.Id == id);
        }

        private MiniAppDbContext MiniAppDbContext
        {
            get { return context as MiniAppDbContext; }
        }
    }
}
