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
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IAddressRepository addressRepository, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _companyRepository = companyRepository;
            _addressRepository = addressRepository;
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

            //company.Id = Guid.NewGuid();
            //company.AddressId = Guid.NewGuid();
            //company.Address.Id = company.AddressId.Value;

            if (!ExecuteValidation(new CompanyValidation(), company)
                || !ExecuteValidation(new AddressValidation(), company.Address)) return null;



            if (_companyRepository.Get(c => c.Document == company.Document).Result.Any())
            {
                Notify("There is already a company with the document informed.");

                return null;
            }

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

            await _companyRepository.Update(company);

            return _mapper.Map<CompanyViewModel>(company);
        }

        public async Task UpdateAddress(Address address)
        {
            if (!ExecuteValidation(new AddressValidation(), address)) return;

            await _addressRepository.Update(address);
        }

        public async Task<bool> Delete(Guid id)
        {

            if (!_companyRepository.Get(c => c.Id == id).Result.Any())
            {
                Notify("Company does not exists.");

                return false;
            }

            if (_companyRepository.GetCompanyJobOffersAddress(id).Result.JobOffers.Any())
            {
                Notify("The company has registered contracts.");
                return false;
            }

            var address = await _addressRepository.GetAddressByCompany(id);

            await _companyRepository.Delete(id);

            if (address != null)
            {
                await _addressRepository.Delete(address.Id);
            }

            return true;

        }

        public void Dispose()
        {
            _addressRepository?.Dispose();
            _companyRepository?.Dispose();
        }
    }
}