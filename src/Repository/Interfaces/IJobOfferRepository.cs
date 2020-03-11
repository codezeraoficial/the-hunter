using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IJobOfferRepository : IRepository<JobOffer>
    {
        Task<IEnumerable<JobOffer>> GetJobOffersByCompany(Guid companyId);
        Task<IEnumerable<JobOffer>> GetJobOffersCompanies();
        Task<JobOffer> GetJobOfferCompany(Guid id);
        Task<JobOffer> GetJobOfferCompanyOccupation(Guid id);
    }
}
