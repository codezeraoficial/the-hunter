using Jobber.IO.Business.Interfaces;
using Jobber.IO.Business.Models;
using Jobber.IO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Jobber.IO.Data.Repository
{
    public class AddressRepository: Repository<Address>, IAddressRepository
    {
        public AddressRepository(JobberDbContext context) : base(context) { }

        public async Task<Address> GetAddressByCompany(Guid companyId)
        {
            return await jobberDbContext.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(a => a.CompanyId == companyId);
        }

        public async Task<Address> GetAddressByEmployee(Guid employeeId)
        {
            return await jobberDbContext.Addresses.AsNoTracking()
               .FirstOrDefaultAsync(a => a.EmployeeId == employeeId);
        }
    }
}
