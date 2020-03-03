using GoHunter.Business.Interfaces;
using GoHunter.Business.Models;
using GoHunter.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GoHunter.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(GoHunterDbContext context) : base(context) { }

        public async Task<Employee> GetEmployeeAddress(Guid id)
        {
            return await jobberDbContext.Employees
                .AsNoTracking()
                .Include(e => e.Address)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> GetEmployeeTechsSkillsOccupations(Guid id)
        {
            return await jobberDbContext.Employees
                .AsNoTracking()
                .Include(e => e.Techs)
                .Include(e => e.Skills)
                .Include(e => e.Occupations)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
