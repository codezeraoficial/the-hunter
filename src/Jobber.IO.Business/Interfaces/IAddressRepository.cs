using Jobber.IO.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jobber.IO.Business.Interfaces
{
    public interface IAddressRepository: IRepository<Address>
    {
        Task<Address> GetAddressByEmployee(Guid employeeId);
        Task<Address> GetAddressByCompany(Guid companyId);
    }
}
