using Repository.Interfaces;
using Service.Interfaces;
using Domain.Models;
using Domain.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class JobOfferService : BaseService, IJobOfferService
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IOccupationRepository _occupationRepository;
        private readonly ICompanyRepository _companyrepository;

        public JobOfferService(IJobOfferRepository jobOfferRepository, 
                               IOccupationRepository occupationRepository, 
                               INotifier notifier, 
                               ICompanyRepository companyRepository) : base(notifier)
        {
            _jobOfferRepository = jobOfferRepository;
            _occupationRepository = occupationRepository;
            _companyrepository = companyRepository;
        }

        public async Task<JobOffer> Add(JobOffer jobOffer)
        {
            jobOffer.Id = Guid.NewGuid();

            if (!ExecuteValidation(new JobOfferValidation(), jobOffer)) return null;

            if (_jobOfferRepository.Get(j=> j.ContractCode == jobOffer.ContractCode).Result.Any())
            {
                Notify("There is already a jobber offer with the contract code informed.");
                return null;
            }

            if (!_companyrepository.Get(j=> j.Id == jobOffer.CompanyId).Result.Any())
            {
                Notify("The company does not exists.");
                return null;
            }

            await _jobOfferRepository.Add(jobOffer);
            return jobOffer;

        }

        public async Task<JobOffer> Update(JobOffer jobOffer)
        {
            if (!ExecuteValidation(new JobOfferValidation(), jobOffer)) return null;

            if (_jobOfferRepository.Get(j=>j.ContractCode == jobOffer.ContractCode && j.Id != jobOffer.Id).Result.Any())
            {
                Notify("Job offer does not exists.");

                return null;
            }

            await _jobOfferRepository.Update(jobOffer);
            return jobOffer;
        }

        public async Task UpdateOccupation(Occupation occupation)
        {
            if (!ExecuteValidation(new OccupationValidation(), occupation)) return;

            await _occupationRepository.Update(occupation);
        }

        public async Task<bool> Delete(Guid id)
        {  
            if (id == null)
            {
                Notify("Job offer does not exists.");
                return false;
            }
            
            await _jobOfferRepository.Delete(id);

     
            return true;
        }

        public void Dispose()
        {
            _occupationRepository?.Dispose();
            _jobOfferRepository?.Dispose();
        }

    }
}
