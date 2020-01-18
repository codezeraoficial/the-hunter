using Jobber.IO.Business.Models;
using System;
using System.Threading.Tasks;

namespace Jobber.IO.Business.Interfaces
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        Task<Employee> GetEmployeeAddress(Guid id);
        Task<Employee> GetEmployeeTechsSkillsOccupations(Guid id);
    }
}
