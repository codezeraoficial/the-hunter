using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITechRepository:IRepository<Tech>
    {
        Task<IEnumerable<Tech>> GetTechsByEmployee(Guid employeeId);
        Task<IEnumerable<Tech>> GetTechsByJobOffer(Guid jobOfferId);
        Task<IEnumerable<Tech>> GetTechsEmployees();
        Task<IEnumerable<Tech>> GetTechsJobOffers();        
        Task<Tech> GetTechEmployee(Guid id);
        Task<Tech> GetTechJoboffer(Guid id);
    }
}
