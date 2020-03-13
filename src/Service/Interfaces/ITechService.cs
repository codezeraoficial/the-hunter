using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITechService
    {
        Task<TechViewModel> Add(TechViewModel techViewModel);
        Task<TechViewModel> Update(TechViewModel techViewModel);
        Task<bool> Delete(Guid Id);

        Task<IEnumerable<TechViewModel>> GetAll();
        Task<TechViewModel> GetById(Guid id);
    }
}
