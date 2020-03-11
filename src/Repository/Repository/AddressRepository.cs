using Repository.Interfaces;
using Domain.Models;
using Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class AddressRepository: Repository<Address>, IAddressRepository
    {
        public AddressRepository(GoHunterDbContext context) : base(context) { }

        public async Task<Address> GetAddressByCompany(Guid companyId)
        {
            return await jobberDbContext.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(a => a.Company.Id == companyId);
        }

        public async Task<Address> GetAddressByEmployee(Guid employeeId)
        {
            return await jobberDbContext.Addresses.AsNoTracking()
               .FirstOrDefaultAsync(a => a.Employee.Id == employeeId);
        }
    }
}
