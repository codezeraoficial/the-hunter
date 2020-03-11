using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAddressRepository: IRepository<Address>
    {
        Task<Address> GetAddressByEmployee(Guid employeeId);
        Task<Address> GetAddressByCompany(Guid companyId);
    }
}
