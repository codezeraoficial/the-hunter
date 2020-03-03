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

        public async Task Add(Company company)
        {
            if (!ExecuteValidation(new CompanyValidation(), company)
               || !ExecuteValidation(new AddressValidation(), company.Address)) return;

            if (_companyRepository.Get(c => c.Document == company.Document).Result.Any())
            {
                Notify("There is already a company with the document informed.");

                return;
            }

            await _companyRepository.Add(company);
        }

        public async Task Update(Company company)
        {
            if (!ExecuteValidation(new CompanyValidation(), company)) return;

            if (_companyRepository.Get(c => c.Document == company.Document && c.Id != company.Id).Result.Any())
            {
                Notify("Company does not exists.");

                return;
            }

            await _companyRepository.Update(company);
        }

        public async Task UpdateAddress(Address address)
        {
            if (!ExecuteValidation(new AddressValidation(), address)) return;

            await _addressRepository.Update(address);
        }

        public async Task Delete(Guid id)
        {
            if (_companyRepository.GetCompanyJobOffersAddress(id).Result.JobOffers.Any())
            {
                Notify("The company has registered contracts.");
                return;
            }

            await _companyRepository.Delete(id);
        }

        public void Dispose()
        {
            _addressRepository?.Dispose();
            _companyRepository?.Dispose();
        }

    }
}
