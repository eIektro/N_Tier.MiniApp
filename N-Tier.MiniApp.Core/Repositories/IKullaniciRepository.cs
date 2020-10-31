using N_Tier.MiniApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Core.Repositories
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        /* TO-DO: Burası en başta kullanıcı(lar)ı ilişkili başka tabloların idlerini kullanarak getirmek gibi ortak olmayan işlemler için yazıldı, şuan kullanılmıyor, refactor edilecek.
                  Şuan için IRepository interface indeki işlemler yeterli. */
        Task<IEnumerable<Kullanici>> GetAllWithAsync(); 
        Task<Kullanici> GetWithByIdAsync(int id);
    }
}
