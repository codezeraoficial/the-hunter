using GoHunter.Business.Models;
using System;
using System.Threading.Tasks;

namespace GoHunter.Business.Interfaces
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        Task<Employee> GetEmployeeAddress(Guid id);
        Task<Employee> GetEmployeeAddressTechsSkillsOccupations(Guid id);
    }
}
