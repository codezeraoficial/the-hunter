using GoHunter.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoHunter.Business.Interfaces
{
    public interface IOccupationRepository:IRepository<Occupation>
    {
        Task<IEnumerable<Occupation>> GetOccupationsByEmployee(Guid employeeId);
        Task<IEnumerable<Occupation>> GetOccupationsByJobOffer(Guid jobOfferId);
        Task<IEnumerable<Occupation>> GetOccupationsEmployees();
        Task<IEnumerable<Occupation>> GetOccupationsJobOffers();
        Task<Occupation> GetOccupationEmployee(Guid id);
        Task<Occupation> GetOccupationJoboffer(Guid id);
    }
}
