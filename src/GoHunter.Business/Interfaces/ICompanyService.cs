using GoHunter.Business.Models;
using System;
using System.Threading.Tasks;

namespace GoHunter.Business.Interfaces
{
    public interface ICompanyService
    {
        Task<bool> Add(Company company);
        Task<bool> Update(Company company);
        Task<bool> Delete(Guid Id);

        Task UpdateAddress(Address address);
    }
}
