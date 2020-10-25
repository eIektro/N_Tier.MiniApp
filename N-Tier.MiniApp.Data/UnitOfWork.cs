using N_Tier.MiniApp.Core;
using N_Tier.MiniApp.Core.Repositories;
using N_Tier.MiniApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiniAppDbContext _context;
        private SirketRepository _sirketRepository;
        private GorevRepository _gorevRepository;
        private KullaniciRepository _kullaniciRepository;


        public UnitOfWork(MiniAppDbContext context)
        {
            this._context = context;
        }

        public IGorevRepository Gorevs => _gorevRepository ?? new GorevRepository(_context);

        public ISirketRepository Sirkets => _sirketRepository ?? new SirketRepository(_context);

        public IKullaniciRepository Kullanicis => _kullaniciRepository ?? new KullaniciRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
