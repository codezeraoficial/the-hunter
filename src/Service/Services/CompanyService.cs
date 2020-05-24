using Domain.Models;
using Domain.Models.Validations;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Threading.Tasks;
using System.Linq;
using Service.ViewModels;
using System.Collections.Generic;
using AutoMapper;

namespace Service.Services
{
    public class CompanyService : BaseService, ICompanyService
    {

        private readonly ICompanyRepository _companyRepository;
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper, INotifier notifier, IAddressService addressService) : base(notifier)
        {
            _companyRepository = companyRepository;
            _addressService = addressService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll());
        }

        public async Task<CompanyViewModel> GetById(Guid id)
        {
            return _mapper.Map<CompanyViewModel>(await _companyRepository.GetCompanyJobOffersAddress(id));
        }

        public async Task<CompanyViewModel> Add(CompanyViewModel companyViewModel)
        {
            var company = _mapper.Map<Company>(companyViewModel);

            if (!ExecuteValidation(new CompanyValidation(), company))
                return null;

            if (_companyRepository.Get(c => c.Document == company.Document).Result.Any())
            {
                Notify("There is already a company with the document informed.");

                return null;
            }

            var address = await _addressService.Add(companyViewModel.Address);

            company.LinkAddress(address.Id);

            await _companyRepository.Add(company);
            return _mapper.Map<CompanyViewModel>(company);
        }

        public async Task<CompanyViewModel> Update(CompanyViewModel companyViewModel)
        {
            var company = _mapper.Map<Company>(companyViewModel);

            if (!ExecuteValidation(new CompanyValidation(), company))
                return null;

            if (!_companyRepository.Get(c => c.Id == company.Id).Result.Any())
            {
                Notify("Company does not exists.");

                return null;
            }

            await _addressService.Update(companyViewModel.Address);

            await _companyRepository.Update(company);

            return _mapper.Map<CompanyViewModel>(company);
        }


        public async Task<bool> Delete(Guid id)
        {
            var company = await _companyRepository.GetById(id);

            if (company == null)
            {
                Notify("Company does not exists.");

                return false;
            }

            company.Remove();


            await _addressService.Delete(id);

            await _companyRepository.Delete(id);

            await _companyRepository.Update(company);

            return true;

        }

        public void Dispose()
        {
            _companyRepository?.Dispose();
        }
    }
}