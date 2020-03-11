using Repository.Interfaces;
using Domain.Models;
using Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(GoHunterDbContext context) : base(context) { }

        public async Task<Company> GetCompanyAddress(Guid id)
        {
            return await jobberDbContext.Companies
              .AsNoTracking()
              .Include(c => c.Address)
              .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Company> GetCompanyJobOffersAddress(Guid id)
        {
            return await jobberDbContext.Companies
              .AsNoTracking()
              .Include(c=> c.JobOffers)
              .Include(c => c.Address)              
              .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
