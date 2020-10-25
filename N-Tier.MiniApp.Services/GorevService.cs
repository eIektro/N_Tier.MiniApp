using N_Tier.MiniApp.Core;
using N_Tier.MiniApp.Core.Models;
using N_Tier.MiniApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.Services
{
    public class GorevService : IGorevService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GorevService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Gorev> CreateGorev(Gorev newGorev)
        {
            await _unitOfWork.Gorevs.AddAsync(newGorev);
            await _unitOfWork.CommitAsync();
            return newGorev;
        }

        public async Task DeleteGorev(Gorev gorev)
        {
            _unitOfWork.Gorevs.Remove(gorev);
            await _unitOfWork.CommitAsync(); 
        }

        public async Task<IEnumerable<Gorev>> GetAllGorevs()
        {
            return await _unitOfWork.Gorevs.GetAllWithAsync();
        }

        public async Task<Gorev> GetGorevById(int id)
        {
            return await _unitOfWork.Gorevs.GetByIdAsync(id);
        }

        public async Task UpdateGorev(Gorev gorevToBeUpdated, Gorev gorev)
        {
            gorevToBeUpdated.Gorevadi = gorev.Gorevadi ?? gorevToBeUpdated.Gorevadi;
            gorevToBeUpdated.Gorevtanimi = gorev.Gorevtanimi ?? gorevToBeUpdated.Gorevtanimi;
            

            await _unitOfWork.CommitAsync();
        }
    }
}
