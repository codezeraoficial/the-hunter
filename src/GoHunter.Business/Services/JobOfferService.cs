using GoHunter.Business.Interfaces;
using GoHunter.Business.Models;
using GoHunter.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GoHunter.Business.Services
{
    public class JobOfferService : BaseService, IJobOfferService
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IOccupationRepository _occupationRepository;

        public JobOfferService(IJobOfferRepository jobOfferRepository, IOccupationRepository occupationRepository, INotifier notifier): base(notifier)
        {
            _jobOfferRepository = jobOfferRepository;
            _occupationRepository = occupationRepository;
        }

        public async Task<JobOffer> Add(JobOffer jobOffer)
        {
            jobOffer.Id = Guid.NewGuid();
            jobOffer.OccupationId = Guid.NewGuid();
            jobOffer.Occupation.Id = jobOffer.OccupationId;

            if (!ExecuteValidation(new JobOfferValidation(), jobOffer)
                || !ExecuteValidation(new OccupationValidation(), jobOffer.Occupation)) return null;

            if (_jobOfferRepository.Get(j=> j.ContractCode == jobOffer.ContractCode).Result.Any())
            {
                Notify("There is already a jobber offer with the contract code informed.");

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

            var occupation = await _occupationRepository.GetOccupationJoboffer(id);

            await _jobOfferRepository.Delete(id);

            if (occupation != null)
            {
                await _occupationRepository.Delete(occupation.Id);
            }

            return true;
        }

        public void Dispose()
        {
            _occupationRepository?.Dispose();
            _jobOfferRepository?.Dispose();
        }

    }
}
