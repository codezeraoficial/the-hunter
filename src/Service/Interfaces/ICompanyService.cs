using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyViewModel>> GetAll();
        Task<CompanyViewModel> GetById(Guid id);
        Task<CompanyViewModel> Add(CompanyViewModel company);
        Task<CompanyViewModel> Update(CompanyViewModel company);
        Task<bool> Delete(Guid Id);
    }
}
