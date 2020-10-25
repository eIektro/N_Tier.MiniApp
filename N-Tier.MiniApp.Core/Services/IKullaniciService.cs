using N_Tier.MiniApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Core.Services
{
    public interface IKullaniciService
    {
        Task<IEnumerable<Kullanici>> GetAllKullanicis();
        Task<Kullanici> GetKullaniciById(int id);
        //TO-DO: Kullanicilari SirketID si veya GorevID sine göre getirecek eklemeler yapılacak.
        Task<Kullanici> CreateKullanici(Kullanici newKullanici);
        Task UpdateKullanici(Kullanici kullaniciToBeUpdated, Kullanici artist);
        Task DeleteKullanici(Kullanici kullanici);
    }
}
