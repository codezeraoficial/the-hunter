using GoHunter.Business.Models;
using System;
using System.Threading.Tasks;

namespace GoHunter.Business.Interfaces
{
    public interface ICompanyService
    {
        Task Add(Company company);
        Task Update(Company company);
        Task Delete(Guid Id);

        Task UpdateAddress(Address address);
    }
}
