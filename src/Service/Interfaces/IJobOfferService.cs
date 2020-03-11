using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IJobOfferService
    {
        Task<JobOffer> Add(JobOffer jobOffer);
        Task<JobOffer> Update(JobOffer jobOffer);
        Task<bool> Delete(Guid Id);

        Task UpdateOccupation(Occupation occupation);
    }
}
