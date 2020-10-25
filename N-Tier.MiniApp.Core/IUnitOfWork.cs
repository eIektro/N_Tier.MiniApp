using N_Tier.MiniApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IGorevRepository Gorevs { get; }
        ISirketRepository Sirkets { get; }
        IKullaniciRepository Kullanicis { get; }
        Task<int> CommitAsync();
    }
}
