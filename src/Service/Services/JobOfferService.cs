using AutoMapper;
using Domain.Models;
using Domain.Models.Validations;
using Repository.Interfaces;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class JobOfferService : BaseService, IJobOfferService
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IOccupationRepository _occupationRepository;
        private readonly ICompanyRepository _companyrepository;
        private readonly IMapper _mapper;

        public JobOfferService(IJobOfferRepository jobOfferRepository, 
                               IOccupationRepository occupationRepository, 
                               INotifier notifier,
                               IMapper mapper,
                               ICompanyRepository companyRepository) : base(notifier)
        {
            _jobOfferRepository = jobOfferRepository;
            _occupationRepository = occupationRepository;
            _companyrepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobOfferViewModel>> GetAll()
        {
            return  _mapper.Map<IEnumerable<JobOfferViewModel>>(await _jobOfferRepository.GetAll());
        }

        public async Task<JobOfferViewModel> GetById(Guid id)
        {
            return _mapper.Map<JobOfferViewModel>(await _jobOfferRepository.GetJobOfferCompany(id));
        }

        public async Task<JobOfferViewModel> Add(JobOfferViewModel jobOfferViewModel)
        {
            var jobOffer = _mapper.Map<JobOffer>(jobOfferViewModel);

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
            return _mapper.Map<JobOfferViewModel>(jobOffer);

        }

        public async Task<JobOfferViewModel> Update(JobOfferViewModel jobOfferViewModel)
        {
            var jobOffer = _mapper.Map<JobOffer>(jobOfferViewModel);

            if (!ExecuteValidation(new JobOfferValidation(), jobOffer)) return null;

            if (!_companyrepository.Get(j => j.Id == jobOffer.CompanyId).Result.Any())
            {
                Notify("The company does not exists.");
                return null;
            }

            if (!_jobOfferRepository.Get(j=>j.Id == jobOffer.Id).Result.Any())
            {
                Notify("Job offer does not exists.");

                return null;
            }

            await _jobOfferRepository.Update(jobOffer);
            return _mapper.Map<JobOfferViewModel>(jobOffer);
        }

        public async Task UpdateOccupation(Occupation occupation)
        {
            if (!ExecuteValidation(new OccupationValidation(), occupation)) return;

            await _occupationRepository.Update(occupation);
        }

        public async Task<bool> Delete(Guid id)
        {
            if (!_jobOfferRepository.Get(j => j.Id == id).Result.Any())
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
