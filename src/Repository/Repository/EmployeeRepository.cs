using Repository.Interfaces;
using Domain.Models;
using Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(GoHunterDbContext context) : base(context) { }

        public async Task<Employee> GetEmployeeAddress(Guid id)
        {
            return await goHunterContext.Employees
                .AsNoTracking()
                .Include(e => e.Address)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> GetEmployeeAddressTechsSkillsOccupations(Guid id)
        {
            return await goHunterContext.Employees
                .AsNoTracking()
                .Include(e => e.Techs)
                .Include(e => e.Skills)
                .Include(e => e.Occupations)
                .Include(e=> e.Address)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
