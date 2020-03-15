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
    public class JobOfferRepository: Repository<JobOffer>, IJobOfferRepository
    {
        public JobOfferRepository(GoHunterDbContext context ): base(context) { }

        public async Task<JobOffer> GetJobOfferCompany(Guid id)
        {
            return await goHunterContext.JobOffers
                .AsNoTracking()                
                .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<IEnumerable<JobOffer>> GetJobOffersByCompany(Guid companyId)
        {
            return await Get(j => j.CompanyId == companyId);
        }

        public async Task<IEnumerable<JobOffer>> GetJobOffersCompanies()
        {
            return await goHunterContext.JobOffers
                .AsNoTracking()                
                .OrderBy(j => j.Name).ToListAsync();
        }

        public async Task<JobOffer> GetJobOfferCompanyOccupation(Guid id)
        {
            return await goHunterContext.JobOffers
              .AsNoTracking()
              .Include(c => c.Occupation)              
              .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
