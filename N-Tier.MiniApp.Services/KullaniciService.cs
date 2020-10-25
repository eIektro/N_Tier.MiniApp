using N_Tier.MiniApp.Core;
using N_Tier.MiniApp.Core.Models;
using N_Tier.MiniApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Services
{
    public class KullaniciService : IKullaniciService
    {
        private readonly IUnitOfWork _unitOfWork;

        public KullaniciService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Kullanici> CreateKullanici(Kullanici newKullanici)
        {
            await _unitOfWork.Kullanicis
                .AddAsync(newKullanici);
            await _unitOfWork.CommitAsync();
            return newKullanici;
        }

        public async Task DeleteKullanici(Kullanici kullanici)
        {
            _unitOfWork.Kullanicis.Remove(kullanici);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Kullanici>> GetAllKullanicis()
        {
            return await _unitOfWork.Kullanicis.GetAllAsync();
        }

        public async Task<Kullanici> GetKullaniciById(int id)
        {
            return await _unitOfWork.Kullanicis.GetByIdAsync(id);
        }

        public async Task UpdateKullanici(Kullanici kullaniciToBeUpdated, Kullanici kullanici)
        {
            // TO-DO: Bu atama işlemini yapmanın daha efektif bir yolu bulunacak.
            kullaniciToBeUpdated.Isim = kullanici.Isim ?? kullaniciToBeUpdated.Isim;
            kullaniciToBeUpdated.Soyisim = kullanici.Soyisim ?? kullaniciToBeUpdated.Soyisim;
            kullaniciToBeUpdated.Gorev = kullanici.Gorev ?? kullaniciToBeUpdated.Gorev;
            kullaniciToBeUpdated.Pasword = kullanici.Pasword ?? kullaniciToBeUpdated.Pasword;
            kullaniciToBeUpdated.Sirket = kullanici.Sirket ?? kullaniciToBeUpdated.Sirket;
            kullaniciToBeUpdated.Dogumtarihi = kullanici.Dogumtarihi ?? kullaniciToBeUpdated.Dogumtarihi;
            kullaniciToBeUpdated.Email = kullanici.Email ?? kullaniciToBeUpdated.Email;
            

            await _unitOfWork.CommitAsync();
        }
    }
}
