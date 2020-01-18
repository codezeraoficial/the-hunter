using Jobber.IO.Business.Interfaces;
using Jobber.IO.Business.Models;
using Jobber.IO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Jobber.IO.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(JobberDbContext context) : base(context) { }

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
