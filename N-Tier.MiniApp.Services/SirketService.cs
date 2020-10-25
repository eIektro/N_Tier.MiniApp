using N_Tier.MiniApp.Core;
using N_Tier.MiniApp.Core.Models;
using N_Tier.MiniApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Services
{
    public class SirketService : ISirketService
    {

        private readonly IUnitOfWork _unitOfWork;

        public SirketService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Sirket> CreateSirket(Sirket newSirket)
        {
            await _unitOfWork.Sirkets.AddAsync(newSirket);
            await _unitOfWork.CommitAsync();
            return newSirket;
        }

        public async Task DeleteSirket(Sirket sirket)
        {
            _unitOfWork.Sirkets.Remove(sirket);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Sirket>> GetAllSirkets()
        {
            return await _unitOfWork.Sirkets.GetAllAsync();
        }

        public async Task<Sirket> GetSirketById(int id)
        {
            return await _unitOfWork.Sirkets.GetByIdAsync(id);
        }

        public async Task UpdateSirket(Sirket sirketToBeUpdated, Sirket sirket)
        {
            sirketToBeUpdated.Sirketadi = sirket.Sirketadi ?? sirketToBeUpdated.Sirketadi;
            sirketToBeUpdated.Logo = sirket.Logo ?? sirketToBeUpdated.Logo;
            sirketToBeUpdated.Unvan = sirket.Unvan ?? sirketToBeUpdated.Unvan;
            sirketToBeUpdated.Adres = sirket.Adres ?? sirketToBeUpdated.Adres;
            sirketToBeUpdated.Email = sirket.Email ?? sirketToBeUpdated.Email;

            await _unitOfWork.CommitAsync();
        }
    }
}
