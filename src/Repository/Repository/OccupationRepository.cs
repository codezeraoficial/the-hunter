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
    public class OccupationRepository : Repository<Occupation>, IOccupationRepository
    {
        public OccupationRepository(GoHunterDbContext context) : base(context) { }

        public async Task<Occupation> GetOccupationEmployee(Guid id)
        {
            return await jobberDbContext.Occupations.AsNoTracking().Include(o => o.Employee)
                .FirstOrDefaultAsync(o => o.Id == id);
        }  

        public async Task<IEnumerable<Occupation>> GetOccupationsByEmployee(Guid employeeId)
        {
            return await Get(o => o.EmployeeId == employeeId);           
        }

        public async Task<IEnumerable<Occupation>> GetOccupationsByJobOffer(Guid jobOfferId)
        {
            return await Get(o => o.EmployeeId == jobOfferId);
        }

        public async Task<IEnumerable<Occupation>> GetOccupationsEmployees()
        {
            return await jobberDbContext.Occupations.AsNoTracking().Include(o => o.Employee)
               .OrderBy(o => o.Name).ToListAsync();
        } 
    }
}
