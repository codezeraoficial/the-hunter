using GoHunter.Business.Interfaces;
using GoHunter.Business.Models;
using GoHunter.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GoHunter.Data.Repository
{
    public class AddressRepository: Repository<Address>, IAddressRepository
    {
        public AddressRepository(GoHunterDbContext context) : base(context) { }

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
