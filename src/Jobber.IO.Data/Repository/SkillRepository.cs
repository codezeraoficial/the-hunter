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
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(JobberDbContext context) : base(context) { }

        public async Task<Skill> GetSkillEmployee(Guid id)
        {
            return await jobberDbContext.Skills.AsNoTracking().Include(s => s.Employee)
              .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Skill> GetSkillJoboffer(Guid id)
        {
            return await jobberDbContext.Skills.AsNoTracking().Include(s => s.JobOffer)
             .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Skill>> GetSkillsByEmployee(Guid employeeId)
        {
            return await Get(s => s.EmployeeId == employeeId);
        }

        public async Task<IEnumerable<Skill>> GetSkillsByJobOffer(Guid jobOfferId)
        {
            return await Get(s => s.EmployeeId == jobOfferId);
        }

        public async Task<IEnumerable<Skill>> GetSkillsEmployees()
        {
            return await jobberDbContext.Skills.AsNoTracking().Include(s => s.Employee)
             .OrderBy(s => s.Name).ToListAsync();
        }

        public async Task<IEnumerable<Skill>> GetSkillsJobOffers()
        {
            return await jobberDbContext.Skills.AsNoTracking().Include(s => s.JobOffer)
               .OrderBy(s => s.Name).ToListAsync();
        }
    }
}
