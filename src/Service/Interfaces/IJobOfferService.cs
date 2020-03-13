using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IJobOfferService
    {
        Task<JobOfferViewModel> Add(JobOfferViewModel jobOfferViewModel);
        Task<JobOfferViewModel> Update(JobOfferViewModel jobOfferViewModel);
        Task<bool> Delete(Guid Id);

        Task UpdateOccupation(Occupation occupation);
        Task<IEnumerable<JobOfferViewModel>> GetAll();
        Task<JobOfferViewModel> GetById(Guid id);
    }
}
