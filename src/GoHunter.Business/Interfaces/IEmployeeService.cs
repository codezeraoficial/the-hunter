using GoHunter.Business.Models;
using System;
using System.Threading.Tasks;

namespace GoHunter.Business.Interfaces
{
    public interface IEmployeeService
    {
        Task Add(Employee employee);
        Task Update(Employee employee);
        Task Delete(Guid Id);

        Task UpdateAddress(Address address);
    }
}
