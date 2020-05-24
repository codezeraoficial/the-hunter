using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeViewModel>> GetAll();
        Task<EmployeeViewModel> GetById(Guid Id);
        Task<EmployeeViewModel> Add(EmployeeViewModel employeeViewModel);
        Task<EmployeeViewModel> Update(EmployeeViewModel employeeViewModel);
        Task<bool> Delete(Guid Id);
   
    }
}
