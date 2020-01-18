using Jobber.IO.Business.Interfaces;
using Jobber.IO.Business.Models;
using Jobber.IO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobber.IO.Data.Repository
{
    public class JobOfferRepository: Repository<JobOffer>, IJobOfferRepository
    {
        public JobOfferRepository(JobberDbContext context ): base(context) { }

        public async Task<JobOffer> GetJobOfferCompany(Guid id)
        {
            return await jobberDbContext.JobOffers
                .AsNoTracking()
                .Include(j => j.Company)
                .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<IEnumerable<JobOffer>> GetJobOffersByCompany(Guid companyId)
        {
            return await Get(j => j.CompanyId == companyId);
        }

        public async Task<IEnumerable<JobOffer>> GetJobOffersCompanies()
        {
            return await jobberDbContext.JobOffers
                .AsNoTracking()
                .Include(j => j.Company)
                .OrderBy(j => j.Name).ToListAsync();
        }
    }
}
