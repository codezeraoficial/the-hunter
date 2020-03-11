using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        Task<Employee> GetEmployeeAddress(Guid id);
        Task<Employee> GetEmployeeAddressTechsSkillsOccupations(Guid id);
    }
}
