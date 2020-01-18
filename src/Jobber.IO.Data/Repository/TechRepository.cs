using Jobber.IO.Business.Interfaces;
using Jobber.IO.Business.Models;
using Jobber.IO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobber.IO.Data.Repository
{
    public class TechRepository : Repository<Tech>, ITechRepository
    {
        public TechRepository(JobberDbContext context) : base(context) { }

        public async Task<Tech> GetTechEmployee(Guid id)
        {
            return await jobberDbContext.Techs.AsNoTracking().Include(t => t.Employee)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tech> GetTechJoboffer(Guid id)
        {
            return await jobberDbContext.Techs.AsNoTracking().Include(t => t.JobOffer)
               .FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<IEnumerable<Tech>> GetTechsEmployees()
        {
            return await jobberDbContext.Techs.AsNoTracking().Include(t => t.Employee)
                .OrderBy(t => t.Name).ToListAsync();                
        }

        public async Task<IEnumerable<Tech>> GetTechsJobOffers()
        {
            return await jobberDbContext.Techs.AsNoTracking().Include(t => t.JobOffer)
               .OrderBy(t => t.Name).ToListAsync();
        }
        public async Task<IEnumerable<Tech>> GetTechsByEmployee(Guid employeeId)
        {
            return await Get(t => t.EmployeeId == employeeId);
        }

        public async Task<IEnumerable<Tech>> GetTechsByJobOffer(Guid jobOfferId)
        {
            return await Get(t => t.JobOfferId == jobOfferId);
        }

  
    }
}
