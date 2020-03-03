using GoHunter.Business.Interfaces;
using GoHunter.Business.Models;
using GoHunter.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoHunter.Data.Repository
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(GoHunterDbContext context) : base(context) { }

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
