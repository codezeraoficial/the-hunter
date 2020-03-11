using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IOccupationRepository:IRepository<Occupation>
    {
        Task<IEnumerable<Occupation>> GetOccupationsByEmployee(Guid employeeId);
        Task<IEnumerable<Occupation>> GetOccupationsByJobOffer(Guid jobOfferId);
        Task<IEnumerable<Occupation>> GetOccupationsEmployees();
        Task<Occupation> GetOccupationEmployee(Guid id);
    }
}
