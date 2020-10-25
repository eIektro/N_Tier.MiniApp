using Microsoft.EntityFrameworkCore;
using N_Tier.MiniApp.Core.Models;
using N_Tier.MiniApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Data.Repositories
{
    public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(MiniAppDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Kullanici>> GetAllWithAsync()
        {
            //TO-DO: Burada kaldım.
            return await MiniAppDbContext.Kullanici.ToListAsync();
        }

        public Task<Kullanici> GetWithByIdAsync(int id)
        {
            return MiniAppDbContext.Kullanici.SingleOrDefaultAsync(a => a.Id == id); 
        }
        private MiniAppDbContext MiniAppDbContext
        {
            get { return context as MiniAppDbContext; }
        }
    }
}
