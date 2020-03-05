using GoHunter.Business.Models;
using System;
using System.Threading.Tasks;

namespace GoHunter.Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<bool> Delete(Guid Id);

        Task UpdateAddress(Address address);
    }
}
