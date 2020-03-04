using GoHunter.Business.Models;
using GoHunter.Business.Models.Validations;
using GoHunter.Business.Interfaces;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace GoHunter.Business.Services
{
    public class CompanyrService : BaseService, ICompanyService
    {

        private readonly ICompanyRepository _companyRepository;
        private readonly IAddressRepository _addressRepository;

        public CompanyrService(ICompanyRepository companyRepository, IAddressRepository addressRepository, INotifier notifier) : base(notifier)
        {
            _companyRepository = companyRepository;
            _addressRepository = addressRepository;
        }

        public async Task<bool> Add(Company company)
        {
            if (!ExecuteValidation(new CompanyValidation(), company)
               || !ExecuteValidation(new AddressValidation(), company.Address)) return false;

            if (_companyRepository.Get(c => c.Document == company.Document).Result.Any())
            {
                Notify("There is already a company with the document informed.");

                return false;
            }

            await _companyRepository.Add(company);
            return true;
        }

        public async Task<bool> Update(Company company)
        {
            if (!ExecuteValidation(new CompanyValidation(), company)) return false;

            if (_companyRepository.Get(c => c.Document == company.Document && c.Id != company.Id).Result.Any())
            {
                Notify("Company does not exists.");

                return false;
            }

            await _companyRepository.Update(company);
            return true;
        }

        public async Task UpdateAddress(Address address)
        {
            if (!ExecuteValidation(new AddressValidation(), address)) return;

            await _addressRepository.Update(address);
        }

        public async Task<bool> Delete(Guid id)
        {
            if (_companyRepository.GetCompanyJobOffersAddress(id).Result.JobOffers.Any())
            {
                Notify("The company has registered contracts.");
                return false;
            }

            var address = await _addressRepository.GetAddressByCompany(id);

            if(address != null)
            {
                await _addressRepository.Delete(address.Id);
            }

            await _companyRepository.Delete(id);
            return true;
        }

        public void Dispose()
        {
            _addressRepository?.Dispose();
            _companyRepository?.Dispose();
        }

    }
}
