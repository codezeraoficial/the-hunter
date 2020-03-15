using Repository.Interfaces;
using Domain.Models;
using Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class TechRepository : Repository<Tech>, ITechRepository
    {
        public TechRepository(GoHunterDbContext context) : base(context) { }

        public async Task<Tech> GetTechEmployee(Guid id)
        {
            return await goHunterContext.Techs.AsNoTracking().Include(t => t.Employee)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tech> GetTechJoboffer(Guid id)
        {
            return await goHunterContext.Techs.AsNoTracking().Include(t => t.JobOffer)
               .FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<IEnumerable<Tech>> GetTechsEmployees()
        {
            return await goHunterContext.Techs.AsNoTracking().Include(t => t.Employee)
                .OrderBy(t => t.Name).ToListAsync();                
        }

        public async Task<IEnumerable<Tech>> GetTechsJobOffers()
        {
            return await goHunterContext.Techs.AsNoTracking().Include(t => t.JobOffer)
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
