using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<bool> Delete(Guid Id);

        Task UpdateAddress(Address address);
    }
}
