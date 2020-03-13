using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOccupationService
    {
        Task<OccupationViewModel> Add(OccupationViewModel occupationViewModel);
        Task<OccupationViewModel> Update(OccupationViewModel occupationViewModel);
        Task<bool> Delete(Guid Id);

        Task<IEnumerable<OccupationViewModel>> GetAll();
        Task<OccupationViewModel> GetById(Guid id);
    }
}
